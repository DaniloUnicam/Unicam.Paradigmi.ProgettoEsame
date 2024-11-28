using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
	public class CategoryDTO
	{
        public CategoryDTO()
        {
 
        }

        public CategoryDTO(Category category)
        {
            CategoryName = category.CategoryName;
            IdCategory = category.IdCategory;
        }

        public string CategoryName { get; set; } = string.Empty;

        public int IdCategory { get; set; }

    }
}
