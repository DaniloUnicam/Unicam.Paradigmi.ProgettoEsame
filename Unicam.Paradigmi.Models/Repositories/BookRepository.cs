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

		public async Task<List<Book>> GetBooksAsync(int page, int pageSize,
		string? bookName, DateTime? publicationTime, string? author)
		{
			var query = _ctx.Books.AsQueryable();

			query = query.Include(b => b.Categories);

			query = FilterByBookTitle(query, bookName);
			query = FilterByPublicationTime(query, publicationTime);
			query = FilterByAuthor(query, author);


			return await query.OrderBy(q => q.BookName)
				.Skip(page * pageSize)
				.Take(pageSize)
				.ToListAsync();
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
