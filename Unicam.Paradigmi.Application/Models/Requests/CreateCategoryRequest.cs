using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class CreateCategoryRequest
	{
		public string Name { get; set; } = string.Empty;

		public Category ToEntity()
		{
			var category = new Category
			{
				CategoryName = Name
			};
			return category;
		}
	}
}
