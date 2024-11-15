using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface IBookService
	{
		Category GetCategory(Book IdBook,string category);

		List<Category> GetCategoriesOfBook(Book IdBook);

		Task UpdateBookAsync(Book book);
		Task UploadBookAsync(Book book);
		Task DeleteBookAsync(Book book);

		public Book GetBook(int IdBook);
	}
}
