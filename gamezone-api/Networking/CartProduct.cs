using System;
namespace gamezone_api.Models
{
	public class CartProduct
	{
		public long ProductId { get; set; }

		public string Name { get; set; }

		public double Price { get; set; }

		public int Quantity { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            var cartProduct = obj as CartProduct;
            return
                this.ProductId == cartProduct.ProductId &&
                this.Name == cartProduct.Name &&
                this.Price == cartProduct.Price &&
                this.Quantity == cartProduct.Quantity;
        }
    }
}

