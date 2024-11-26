using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface ICategoryService
	{
		bool EmptyCategory(string categoryName);

		Task AddCategoryAsync(Category category);

		Task DeleteCategoryAsync(Category category);


	}
}
