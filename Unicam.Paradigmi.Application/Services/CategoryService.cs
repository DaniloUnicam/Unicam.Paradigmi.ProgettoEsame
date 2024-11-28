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

		public async Task<Category> CreateCategoryAsync(Category category)
		{
			if(await _categoryRepository.CategoryExists(category.CategoryName))
			{
				throw new InvalidOperationException($"{category.CategoryName} already exists");
			}

			_categoryRepository.AddEntity(category);
			await _categoryRepository.SaveChangesAsync();
			return category;
		}

		public async Task<bool> DeleteCategoryAsync(int IdCategory)
		{
			var category = GetCategoryByIdAsync(IdCategory);

			if (category.Result == null)
			{
				throw new KeyNotFoundException($"Category {IdCategory} not found");
			}

			_categoryRepository.Delete(category.Result);
			await _categoryRepository.SaveChangesAsync();
			return true;
		}

		private async Task<Category?> GetCategoryByIdAsync(int id)
		{
			return await _categoryRepository.GetCategoryByIdAsync(id);
		}
	}
}
