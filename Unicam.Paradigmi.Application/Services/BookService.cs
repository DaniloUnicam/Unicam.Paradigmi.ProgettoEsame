using System.Collections.Immutable;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class BookService : IBookService
	{
		private readonly BookRepository _bookRepository;
		private readonly CategoryRepository _categoryRepository;
		public BookService(BookRepository libroRepository, CategoryRepository categoryRepository)
		{
			_bookRepository = libroRepository;
			_categoryRepository = categoryRepository;
		}

		public async Task<List<Book>> GetBookAsync(int page, int pageSize,
		string? bookName, DateTime? publicationTime, string? author)
		{
			return await _bookRepository.GetBooksAsync(page, pageSize, bookName, publicationTime, author);
		}

		public async Task<Book> CreateBookAsync(Book book, ICollection<int> categoryIds)
		{
			var categories = await GetCategoriesAsync(categoryIds);
			if (categories == null) throw new KeyNotFoundException("Categories not found");

			book.Categories = categories.Select(c => new BookCategory
			{
				Book = book,
				Category = c
			}).ToList();

			_bookRepository.AddEntity(book);
			await _bookRepository.SaveChangesAsync();
			return book;
		}

		public async Task<Book> UpdateBookAsync(BookDTO bookDto, ICollection<int> categoryIds)
		{
			if (!await AllBookCategoriesExistInDbAsync(categoryIds))
				throw new KeyNotFoundException("Categories not found");

			var targetBook = await _bookRepository.GetBookByIdIncludeBookCategoriesAsync(bookDto.IdBook);

			if (targetBook == null) throw new KeyNotFoundException($"{bookDto.IdBook} not found in database");

			var bookCategoriesToRemove = BookCategoriesToRemove(targetBook.Categories, categoryIds);
			var bookCategoriesToAdd = BookCategoriesToAdd(targetBook.IdBook, targetBook.Categories, categoryIds);

			return await UpdateTargetBookAsync(targetBook, bookDto, bookCategoriesToRemove, bookCategoriesToAdd);
		}

		public async Task<bool> DeleteBookAsync(int bookId)
		{
			var book = await _bookRepository.GetBookByIdAsync(bookId);

			if (book == null) throw new KeyNotFoundException($"Book {bookId} not found");

			_bookRepository.Delete(book);
			await _bookRepository.SaveChangesAsync();

			return true;
		}

		private static ISet<BookCategory> BookCategoriesToRemove(ICollection<BookCategory> bookCategories,
			ICollection<int> categoryIds)
		{
			var categoryIdsSet = categoryIds.ToHashSet();
			return bookCategories.Where(b => !categoryIdsSet.Contains(b.CategoryId)).ToImmutableHashSet();
		}

		private static ICollection<BookCategory> BookCategoriesToAdd(int bookId, ICollection<BookCategory> bookCategories,
			ICollection<int> categoryIds)
		{
			var bookCategoryIdsSet = bookCategories.Select(c => c.CategoryId).ToHashSet();
			return categoryIds.Where(b => !bookCategoryIdsSet.Contains(b)).Select(c => new BookCategory
			{
				BookId = bookId,
				CategoryId = c
			}).ToImmutableList();
		}

		private static void ModifyNonNullParameters(BookDTO bookDto, Book book)
		{
			if (bookDto.BookTitle != null) book.Title = bookDto.BookTitle;

			if (bookDto.Author != null) book.Author = bookDto.Author;

			if (bookDto.Editor != null) book.Editor = bookDto.Editor;

			if (bookDto.PublicationDate != null) book.PublishDate = bookDto.PublicationDate;
		}

		private async Task<Book> UpdateTargetBookAsync(Book targetBook, BookDTO bookDto,
			ISet<BookCategory> bookCategoriesToRemove, ICollection<BookCategory> bookCategoriesToAdd)
		{
			ModifyNonNullParameters(bookDto, targetBook);
			targetBook.Categories.RemoveAll(bookCategoriesToRemove.Contains);
			targetBook.Categories.AddRange(bookCategoriesToAdd);

			_bookRepository.ApplyChange(targetBook);
			await _bookRepository.SaveChangesAsync();

			return targetBook;
		}


		private async Task<List<Category>?> GetCategoriesAsync(ICollection<int> categoriesIds)
		{
			var categories = await _categoryRepository.GetCategoriesAsCollectionAsync(categoriesIds.ToImmutableHashSet());
			return categories.Count != categoriesIds.Count ? null : categories;
		}

		private async Task<bool> AllBookCategoriesExistInDbAsync(ICollection<int> categories)
		{
			//it makes no difference in terms of efficiency if I use a hash set
			//instead of a list to ef core when it constructs the sql query
			var numberOfExistingCategoriesInDb =
				await _categoryRepository.GetNumberOfExistingCategoriesInCollectionAsync(categories);

			return numberOfExistingCategoriesInDb == categories.Count;
		}
	}


}
