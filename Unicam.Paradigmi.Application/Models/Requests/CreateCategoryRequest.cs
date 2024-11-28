using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class CreateCategoryRequest
	{
		public string CategoryName { get; set; } = string.Empty;

		public virtual Category ToEntity()
		{
			var category = new Category
			{
				CategoryName = CategoryName
			};
			return category;
		}
	}
}
