using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class CategoryService : GenericService<Category>, ICategoryService
	{

		public CategoryService(CategoryRepository categoryRepository) : base(categoryRepository)
        {
            
        }

		public async Task AddCategoryAsync(Category category)
		{
			base.AddEntity(category);
			base.Save();
		}

		public async Task DeleteCategoryAsync(Category category)
		{
			base.Delete(category);
			base.Save();
		}
	}
}
