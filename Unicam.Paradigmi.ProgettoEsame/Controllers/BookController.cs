using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Application.Validators;
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

			var response = new UploadBookResponse
			{
				Book = new BookDTO()
			};
			return Ok(ResponseFactory.WithSuccess(response));
		}




	}
}
