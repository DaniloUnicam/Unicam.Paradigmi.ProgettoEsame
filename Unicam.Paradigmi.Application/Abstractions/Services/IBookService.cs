using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface IBookService
	{

		Task<(List<Book> Books, int TotalCount)> GetBooksByFiltersAsync(
			string? categoryName, string? bookName, DateTime? publicationDate,
			string? author, string? editor, int page, int pageSize);

		Task<Book> CreateBookAsync(Book book, ICollection<int> categoryIds);

		Task<Book> UpdateBookAsync(BookDTO bookDto, ICollection<int> categoryIds);

		Task<bool> DeleteBookAsync(int bookId);


	}
}
