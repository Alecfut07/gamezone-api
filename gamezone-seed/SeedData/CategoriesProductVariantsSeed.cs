using System;
using gamezone_api;
using gamezone_api.Models;

namespace gamezone_seed.SeedData
{
	public class CategoriesProductVariantsSeed
	{
		private readonly GamezoneContext _context;

		public CategoriesProductVariantsSeed(GamezoneContext context)
		{
			_context = context;
        }

		public List<CategoryProductVariant>? InitData()
		{
            var productVariantsIds = _context.ProductVariants.Select(pv => pv.Id).ToList();

            var parent_category_id_videogame = _context.Categories.Where(c => c.Name == "Video Games").Select(c => c.Id).SingleOrDefault();

            var category_pc_videogame_id = _context.Categories.Where(c => c.Name == "PC" && c.ParentCategoryId == parent_category_id_videogame).Select(c => c.Id).SingleOrDefault();
            var category_ps5_videogame_id = _context.Categories.Where(c => c.Name == "PlayStation 5" && c.ParentCategoryId == parent_category_id_videogame).Select(c => c.Id).SingleOrDefault();
            var category_ps4_videogame_id = _context.Categories.Where(c => c.Name == "PlayStation 4" && c.ParentCategoryId == parent_category_id_videogame).Select(c => c.Id).SingleOrDefault();
            var category_xbox_series_x_s_videogame_id = _context.Categories.Where(c => c.Name == "Xbox Series X | S" && c.ParentCategoryId == parent_category_id_videogame).Select(c => c.Id).SingleOrDefault();
            var category_xbox_one_videogame_id = _context.Categories.Where(c => c.Name == "Xbox One" && c.ParentCategoryId == parent_category_id_videogame).Select(c => c.Id).SingleOrDefault();
            var category_nintendo_switch_videogame_id = _context.Categories.Where(c => c.Name == "Nintendo Switch" && c.ParentCategoryId == parent_category_id_videogame).Select(c => c.Id).SingleOrDefault();
            var category_retro_gaming_videogame_id = _context.Categories.Where(c => c.Name == "Retro Gaming" && c.ParentCategoryId == parent_category_id_videogame).Select(c => c.Id).SingleOrDefault();

            List<CategoryProductVariant> categoriesProductVariantsInit = new List<CategoryProductVariant>
			{
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[0] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[1] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[2] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[3] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[4] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[5] },
				new CategoryProductVariant() { CategoryId = category_xbox_one_videogame_id,        ProductVariantId = productVariantsIds[6] },
				new CategoryProductVariant() { CategoryId = category_xbox_one_videogame_id,        ProductVariantId = productVariantsIds[7] },
				new CategoryProductVariant() { CategoryId = category_pc_videogame_id,              ProductVariantId = productVariantsIds[8] },
				new CategoryProductVariant() { CategoryId = category_nintendo_switch_videogame_id, ProductVariantId = productVariantsIds[9] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[10] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[11] },
				new CategoryProductVariant() { CategoryId = category_nintendo_switch_videogame_id, ProductVariantId = productVariantsIds[12] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[13] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[14] },
				new CategoryProductVariant() { CategoryId = category_pc_videogame_id,              ProductVariantId = productVariantsIds[15] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[16] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[17] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[18] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[19] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[20] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[21] },
				new CategoryProductVariant() { CategoryId = category_xbox_series_x_s_videogame_id, ProductVariantId = productVariantsIds[22] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[23] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[24] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[25] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[26] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[27] },
				new CategoryProductVariant() { CategoryId = category_retro_gaming_videogame_id,    ProductVariantId = productVariantsIds[28] },
				new CategoryProductVariant() { CategoryId = category_nintendo_switch_videogame_id, ProductVariantId = productVariantsIds[29] },
				new CategoryProductVariant() { CategoryId = category_ps5_videogame_id,             ProductVariantId = productVariantsIds[30] },
				new CategoryProductVariant() { CategoryId = category_ps4_videogame_id,             ProductVariantId = productVariantsIds[31] },
				new CategoryProductVariant() { CategoryId = category_xbox_series_x_s_videogame_id, ProductVariantId = productVariantsIds[32] },
			};
			return categoriesProductVariantsInit;
        }
	}
}

