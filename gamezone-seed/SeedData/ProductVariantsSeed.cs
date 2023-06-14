using System;
using gamezone_api;
using gamezone_api.Models;

namespace gamezone_seed.SeedData
{
	public class ProductVariantsSeed
	{
        private readonly GamezoneContext _context;

        public ProductVariantsSeed(GamezoneContext context)
        {
            _context = context;
        }

        public List<ProductVariant>? InitData()
        {
            var productsIds = _context.Products.Select(p => p.Id).ToList();

            var conditionNewId = _context.Conditions.Where(c => c.State == "NEW").Select(c => c.Id).SingleOrDefault();
            var conditionPreOwnedId = _context.Conditions.Where(c => c.State == "PRE_OWNED").Select(c => c.Id).SingleOrDefault();
            var conditionDigitalId = _context.Conditions.Where(c => c.State == "DIGITAL").Select(c => c.Id).SingleOrDefault();

            var editionNormalId = _context.Editions.Where(e => e.Type == "NORMAL").Select(c => c.Id).SingleOrDefault();
            var editionDeluxeId = _context.Editions.Where(e => e.Type == "DELUXE_EDITION").Select(c => c.Id).SingleOrDefault();
            var editionCollectorsId = _context.Editions.Where(e => e.Type == "COLLECTORS_EDITION").Select(c => c.Id).SingleOrDefault();

            List<ProductVariant> productVariantsInit = new List<ProductVariant>
            {
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionNormalId,     Price = 10.20M, ProductId = productsIds[0] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionDeluxeId,     Price = 15.10M, ProductId = productsIds[1] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionCollectorsId, Price = 5.12M,  ProductId = productsIds[2] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionNormalId,     Price = 40.22M, ProductId = productsIds[3] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionDeluxeId,     Price = 32.25M, ProductId = productsIds[4] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionCollectorsId, Price = 12.11M, ProductId = productsIds[5] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionNormalId,     Price = 2.02M,  ProductId = productsIds[6] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionDeluxeId,     Price = 11.11M, ProductId = productsIds[7] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionCollectorsId, Price = 3.33M,  ProductId = productsIds[8] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionNormalId,     Price = 31.31M, ProductId = productsIds[9] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionNormalId,     Price = 60,     ProductId = productsIds[10] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionNormalId,     Price = 21,     ProductId = productsIds[11] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionDeluxeId,     Price = 10.01M, ProductId = productsIds[12] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionDeluxeId,     Price = 9,      ProductId = productsIds[13] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionDeluxeId,     Price = 2,      ProductId = productsIds[14] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionCollectorsId, Price = 45.21M, ProductId = productsIds[15] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionCollectorsId, Price = 40.04M, ProductId = productsIds[16] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionCollectorsId, Price = 12.43M, ProductId = productsIds[17] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionDeluxeId,     Price = 7.07M,  ProductId = productsIds[18] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionCollectorsId, Price = 4.31M,  ProductId = productsIds[19] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionNormalId,     Price = 6.50M,  ProductId = productsIds[20] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionCollectorsId, Price = 17.90M, ProductId = productsIds[21] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionNormalId,     Price = 27,     ProductId = productsIds[22] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionDeluxeId,     Price = 30.08M, ProductId = productsIds[23] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionDeluxeId,     Price = 41.14M, ProductId = productsIds[24] },
                new ProductVariant() { ConditionId = conditionDigitalId,  EditionId = editionNormalId,     Price = 18.89M, ProductId = productsIds[25] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionCollectorsId, Price = 55,     ProductId = productsIds[26] },
                new ProductVariant() { ConditionId = conditionPreOwnedId, EditionId = editionNormalId,     Price = 5,      ProductId = productsIds[27] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionCollectorsId, Price = 46.72M, ProductId = productsIds[28] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionDeluxeId,     Price = 60,     ProductId = productsIds[29] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionNormalId,     Price = 60,     ProductId = productsIds[30] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionNormalId,     Price = 60,     ProductId = productsIds[31] },
                new ProductVariant() { ConditionId = conditionNewId,      EditionId = editionNormalId,     Price = 60,     ProductId = productsIds[32] },
            };
            return productVariantsInit;
        }
    }
}

