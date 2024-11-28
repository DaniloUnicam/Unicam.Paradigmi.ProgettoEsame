using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class DeleteCategoryRequest
	{
		public int IdCategory { get; set; }

		public Category ToEntity()
		{
			var category = new Category
			{
				IdCategory = IdCategory
			};
			return category;
		}
	}
}
