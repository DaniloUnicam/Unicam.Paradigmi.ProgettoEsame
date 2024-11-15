using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Application.Validators;
using Unicam.Paradigmi.Models.Entities;
namespace Unicam.Paradigmi.Web.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class BookController : ControllerBase
	{
		public readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpPost]
		[Route("post")]
		public async Task<IActionResult> UploadBook(UploadBookRequest request)
		{
			var uploadLibroValidator = new UploadBookRequestValidator();
			uploadLibroValidator.Validate(request);
			var book = request.ToEntity();
			await _bookService.UploadBookAsync(book);

			var response = new UploadBookResponse
			{
				Book = new BookDTO()
			};
			return Ok(ResponseFactory.WithSuccess(response));
		}


		[HttpDelete]
		[Route("delete")]
		public async Task<IActionResult> DeleteBook(DeleteBookRequest request)
		{
			var deleteLibroValidator = new DeleteBookRequestValidator();
			deleteLibroValidator.Validate(request);
			var book = request.ToEntity();
			await _bookService.DeleteBookAsync(book);
			
			var response = new DeleteBookResponse
			{
				Book = new BookDTO()
			};
			return Ok(ResponseFactory.WithSuccess(response));
			
		}

		[HttpPut]
		[Route("update")]
		public async Task<IActionResult> UpdateBook(UpdateBookRequest request)
		{
			var updateLibroValidator = new UpdateBookRequestValidator();
			updateLibroValidator.Validate(request);
			var book = request.ToEntity();
			await _bookService.UpdateBookAsync(book);

			var response = new UpdateBookResponse
			{
				Book = new BookDTO()
			};
			return Ok(ResponseFactory.WithSuccess(response));
		}

		[HttpGet]
		[Route("searchName")]
		public async Task<IActionResult> SearchBookName(int IdBook)
		{
			var Book = _bookService.GetBook(IdBook).Nome;
			return Ok(ResponseFactory.WithSuccess(IdBook));
		}

		[HttpGet]
		[Route("searchCategory")]
		public async Task<IActionResult> SearchBookCategory(int IdBook,string category)
		{
			var Book = _bookService.GetBook(IdBook);
			var BookCategory = _bookService.GetCategory(Book, category);
			return Ok(ResponseFactory.WithSuccess(category));
		}

		[HttpGet]
		[Route("searchAutore")]
		public async Task<IActionResult> SearchBookAuthor(int IdBook)
		{
			var BookAuthor = _bookService.GetBook(IdBook).Autore;
			return Ok(ResponseFactory.WithSuccess(BookAuthor));
		}
	}
}
