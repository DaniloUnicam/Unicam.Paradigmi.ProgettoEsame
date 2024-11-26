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
	public class CategoryService : ICategoryService
	{
		public readonly CategoryRepository _categoryRepository;
		public CategoryService(CategoryRepository categoryRepository) 
        {
			_categoryRepository = categoryRepository;
        }

		public async Task AddCategoryAsync(Category category)
		{
			_categoryRepository.AddEntity(category);
			await _categoryRepository.SaveChangesAsync();
		}

		public async Task DeleteCategoryAsync(Category category)
		{
			_categoryRepository.Delete(category);
			await _categoryRepository.SaveChangesAsync();
		}

		public bool EmptyCategory(string categoryName)
		{
			return _categoryRepository.EmptyCategory(categoryName);
		}
	}
}
