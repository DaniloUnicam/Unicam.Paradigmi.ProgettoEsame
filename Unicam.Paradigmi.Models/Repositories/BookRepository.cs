using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
	public class BookRepository : GenericRepository<Book>
	{

		public BookRepository(MyDbContext ctx) : base(ctx) { }

		public static IQueryable<Book> FilterByBookTitle(IQueryable<Book> query, string? bookName)
		{
			if (string.IsNullOrWhiteSpace(bookName))
			{
				return query;
			}
			else
			{
				return query.Where(n => n.BookName.Contains(bookName));
			}
		}

		public static IQueryable<Book> FilterByPublicationTime(IQueryable<Book> query, DateTime? publicationDate)
		{
			if (!publicationDate.HasValue)
			{
				return query;
			}
			else
			{
				return query.Where(t => t.PublishDate.Equals(publicationDate));
			}
		}
		public static IQueryable<Book> FilterByAuthor(IQueryable<Book> query, string? authorName)
		{
			if (string.IsNullOrWhiteSpace(authorName))
			{
				return query;
			}
			else
			{
				return query.Where(n => n.Author.Contains(authorName));
			}
		}

		public async Task<(List<Book> Books, int TotalCount)> GetBooksByFiltersAsync(
			string? categoryName, string? bookName, DateTime? publicationDate,
			string? author, string? editor, int page, int pageSize)
		{
			var query = _ctx.Books
				.Include(b => b.Categories)
				.AsQueryable();

			if (!string.IsNullOrWhiteSpace(categoryName))
			{
				query = query.Where(b => b.Categories.Any(c => c.Category.CategoryName.ToLower().Contains(categoryName.ToLower())));
			}

			if (!string.IsNullOrWhiteSpace(bookName))
			{
				query = query.Where(b => b.BookName.ToLower().Contains(bookName.ToLower()));
			}

			if (publicationDate.HasValue)
			{
				query = query.Where(b => b.PublishDate.Value.Date == publicationDate.Value.Date);
			}

			if (!string.IsNullOrWhiteSpace(author))
			{
				query = query.Where(b => b.Author.ToLower().Contains(author.ToLower()));
			}

			if (!string.IsNullOrWhiteSpace(editor))
			{
				query = query.Where(b => b.Editor.ToLower().Contains(editor));
			}

			// Calcola il totale dei risultati senza impaginazione
			int totalCount = await query.CountAsync();

			// Applica l'ordinamento, il salto e il limite per l'impaginazione
			var books = await query
				.OrderBy(b => b.BookName)
				.Take(page * pageSize)
				.ToListAsync();

			return (books, totalCount);
		}



		public async Task<Book?> GetBookByIdAsync(int bookId)
		{
			return await _ctx.Books.FirstOrDefaultAsync(b => b.IdBook == bookId);
		}

		public async Task<Book?> GetBookByIdIncludeBookCategoriesAsync(int bookId)
		{
			return await _ctx.Books.AsQueryable()
				.Include(b => b.Categories).FirstOrDefaultAsync(b => b.IdBook == bookId); ;
		}



	}
}
