using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class BookService : GenericService<Book>, IBookService
	{

		public BookService(BookRepository libroRepository) : base(libroRepository)
		{

		}

		public Category GetCategory(Book IdBook, string category)
		{
			var book = base.GetEntity(IdBook);
			return book.Categories.FirstOrDefault(c => c.Equals(category));
		}

		public List<Category> GetCategoriesOfBook(Book IdLibro)
		{
			var book = base.GetEntity(IdLibro);
			return book.Categories.ToList();
		}

		public async Task UploadBookAsync(Book book)
		{
			base.AddEntity(book);
			base.Save();
		}

		public async Task DeleteBookAsync(Book book)
		{
			base.Delete(book);
			base.Save();
		}

		public async Task UpdateBookAsync(Book book)
		{
			base.ApplyChange(book);
			base.Save();
		}

		public Book GetBook(int IdBook)
		{
			return base.GetEntityById(IdBook);
		}
	}


}
