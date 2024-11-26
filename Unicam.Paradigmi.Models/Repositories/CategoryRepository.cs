using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
	public class CategoryRepository : GenericRepository<Category>
	{

		public CategoryRepository(MyDbContext context) : base(context)
		{

		}

		public async Task<Category?> GetCategoryByIdAsync(int id)
		{
			return await _ctx.Categories.FirstOrDefaultAsync(x => x.IdCategory == id);
		}

		public async Task<bool> CategoryExists(string name)
		{
			return await _ctx.Categories.AnyAsync(c => c.BookTitle == name);
		}

		public async Task<List<Category>> GetCategoriesAsCollectionAsync(ICollection<int> categoryIds)
		{
			return await _ctx.Categories.Where(c => categoryIds.Contains(c.IdCategory)).ToListAsync();

		}

		public async Task<int> GetNumberOfExistingCategoriesInCollectionAsync(ICollection<int> categoryIds)
		{
			return await _ctx.Categories.CountAsync(c => categoryIds.Contains(c.IdCategory));
		}
	}
}
