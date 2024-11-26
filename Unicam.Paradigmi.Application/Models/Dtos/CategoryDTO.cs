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
            BookTitle = category.CategoryName;
            IdCategory = category.IdCategory;
        }

        public string BookTitle { get; set; } = string.Empty;

        public int IdCategory { get; set; }

    }
}
