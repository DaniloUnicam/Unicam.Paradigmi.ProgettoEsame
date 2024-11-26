using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Factories
{
	public class BookDTOFactory
	{
		public static BookDTO FromBook(Book book)
		{
			return new BookDTO
			{
				IdBook = book.IdBook,
				BookTitle = book.CategoryName,
				Author = book.Author,
				Editor = book.Editor,
				PublicationDate = book.PublishDate,
				Categories = book.Categories.Select(FromBookCategory).ToList()
			};
		}

		private static CategoryDTO FromBookCategory(BookCategory bookCategory)
		{
			return new CategoryDTO
			{
				IdCategory = bookCategory.CategoryId,
				BookTitle = bookCategory.Category?.CategoryName!
			};
		}
	}
}
