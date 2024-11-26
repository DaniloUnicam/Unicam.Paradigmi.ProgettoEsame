using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface IBookService
	{
		Task<List<Book>> GetBookAsync(int page, int pageSize,

		string? bookName, DateTime? publicationTime, string? author);

		Task<Book> CreateBookAsync(Book book, ICollection<int> categoryIds);

		Task<Book> UpdateBookAsync(BookDTO bookDto, ICollection<int> categoryIds);

		Task<bool> DeleteBookAsync(int bookId);


	}
}
