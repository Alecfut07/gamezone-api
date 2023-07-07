using System;
using Stripe;
using gamezone_api.Services.Stripe;
using gamezone_api.Models.Stripe;
using Stripe.Tax;
using Azure.Core;
using gamezone_api.Repositories;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Application
{
    public class PaymentsService : IPaymentsService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        private readonly ICartsRepository _cartsRepository;
        private readonly ICartsMapper _cartsMapper;

        public PaymentsService(ChargeService chargeService, CustomerService customerService, TokenService tokenService, ICartsRepository cartsRepository, ICartsMapper cartsMapper)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
            _cartsRepository = cartsRepository;
            _cartsMapper = cartsMapper;
        }

        public async Task<StripeCustomer> AddStripeCustomerAsync(Models.Stripe.Customer customer, CancellationToken ct)
        {
            // Set Stripe Token options based on customer data
            TokenCreateOptions tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = customer.Name,
                    Number = customer.CreditCard.CardNumber,
                    ExpYear = customer.CreditCard.ExpirationYear,
                    ExpMonth = customer.CreditCard.ExpirationMonth,
                    Cvc = customer.CreditCard.Cvc
                }
            };

            // Create new Stripe Token
            Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

            // Set Customer options using
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email,
                Source = stripeToken.Id
            };

            // Create customer at Stripe
            Stripe.Customer createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);

            // Return the created customer at stripe
            return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
        }

        public long CalculateSubTotal(List<CartProduct> cartProducts)
        {
            double subtotal = 0;
            foreach (var cartProduct in cartProducts)
            {
                subtotal += cartProduct.Price * cartProduct.Quantity * 100;
            }
            return (long)(subtotal);
        }

        public long CalculateTax(string uuid, List<CartProduct> cartProducts, AddressRequest address)
        {
            // Convert each cart item to a Stripe line item object
            var lineItems = new List<CalculationLineItemOptions>();
            foreach (var cartItem in cartProducts)
            {
                lineItems.Add(new CalculationLineItemOptions
                {
                    Reference = cartItem.ProductId.ToString(),
                    Amount = (long?)(cartItem.Quantity * cartItem.Price * 100),
                    Quantity = cartItem.Quantity
                });
            }

            // Create a tax calculation using the Stripe API
            var options = new CalculationCreateOptions
            {
                Currency = "USD",
                LineItems = lineItems,
                CustomerDetails = new CalculationCustomerDetailsOptions
                {
                    Address = new AddressOptions
                    {
                        Line1 = address.Line1,
                        Line2 = address.Line2,
                        City = address.City,
                        State = address.State,
                        PostalCode = address.ZipCode,
                        Country = address.Country,
                    },
                    AddressSource = "billing",
                },
                Expand = new List<string> { "line_items.data.tax_breakdown" },
            };
            var service = new CalculationService();
            var calculation = service.Create(options);

            return calculation.TaxAmountExclusive;
        }

        public long CalculateGrandTotal(long subtotal, long tax)
        {
            var grandtotal = subtotal + tax;
            return grandtotal;
        }

        public async Task<StripePayment> AddStripePaymentAsync(string uuid, string stripeCustomerId, AddressRequest address, Payment payment, CancellationToken ct)
        {
            var list = await _cartsRepository.GetCart(uuid);
            var cartProducts = list.ConvertAll((tuple) =>
            {
                var productId = tuple.Item1;
                var quantity = tuple.Item2;
                var productCacheEntry = tuple.Item3;
                return _cartsMapper.Map(productId, quantity, productCacheEntry);
            });
            var subtotal = CalculateSubTotal(cartProducts);
            var tax = CalculateTax(uuid, cartProducts, address);
            var grandtotal = CalculateGrandTotal(subtotal, tax);

            // Set the options for the payment we would like to create at Stripe
            ChargeCreateOptions paymentOptions = new ChargeCreateOptions
            {
                //Customer = payment.CustomerId,
                Customer = stripeCustomerId,
                ReceiptEmail = payment.ReceiptEmail,
                Description = payment.Description,
                Currency = payment.Currency,
                Amount = grandtotal
            };

            // Create the payment
            var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

            // Return the payment to requesting method
            //return new StripePayment(
            //  createdPayment.CustomerId,
            //  createdPayment.ReceiptEmail,
            //  createdPayment.Description,
            //  createdPayment.Currency,
            //  createdPayment.Amount,
            //  createdPayment.Id);

            return new StripePayment(
                createdPayment.CustomerId,
                createdPayment.Id,
                createdPayment.ReceiptEmail,
                createdPayment.Description,
                createdPayment.Currency,
                subtotal,
                tax,
                createdPayment.Amount);
        }
    }
}

