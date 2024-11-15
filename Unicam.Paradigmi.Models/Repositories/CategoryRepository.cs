using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
	public class CategoryRepository : GenericRepository<Category>
	{

		public CategoryRepository(MyDbContext context) : base(context)
		{

		}

	}
}
