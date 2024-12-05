using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface ICategoryService
	{
		Task<Category> CreateCategoryAsync(Category category);

		Task<bool> DeleteCategoryAsync(int IdCategory);

		Task<bool> CategoryExists(string categoryName);
	}
}
