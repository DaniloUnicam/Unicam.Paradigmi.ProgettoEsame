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
		[Route("create")]
		public async Task<IActionResult> CreateBookAsync(CreateBookRequest request)
		{
			var createBookValidator = new CreateBookRequestValidator();
			createBookValidator.Validate(request);

			var book = request.ToEntity();

			var result = await _bookService.CreateBookAsync(book, request.CategoriesId);

			var createBookResponse = new CreateBookResponse
			{
				BookDTO = BookDTOFactory.FromBook(result)
			};
			return Ok(ResponseFactory.WithSuccess(createBookResponse));
		}

		[HttpPut]
		[Route("update")]
		public async Task<IActionResult> UpdateBookAsync(UpdateBookRequest request)
		{
			var updateBookValidator = new UpdateBookRequestValidator();
			updateBookValidator.Validate(request);

			var book = request.ToDto();

			var result = await _bookService.UpdateBookAsync(book, request.CategoryIds);
			
			var updateBookResponse = new UpdateBookResponse
			{
				Book = new BookDTO()
			};
			return Ok(ResponseFactory.WithSuccess(updateBookResponse));
		}


		[HttpDelete]
		[Route("delete")]
		public async Task<IActionResult> DeleteBookAsync(DeleteBookRequest request)
		{
			var deleteBookValidator = new DeleteBookRequestValidator();
			deleteBookValidator.Validate(request);
			
			var result = await _bookService.DeleteBookAsync(request.IdBook);

			var deleteBookResponse = new DeleteBookResponse
			{
				Result = result
			};
			return Ok(ResponseFactory.WithSuccess(deleteBookResponse));
			
		}



		[HttpPost]
		[Route("get")]
		public async Task<IActionResult> GetBookAsync(GetBookRequest request)
		{
			var getBookValidator = new GetBookRequestValidator();
			getBookValidator.Validate(request);

			var result = await _bookService.GetBookAsync(request.Page, request.PageSize, request.BookName,
				request.PublicationDate, request.Author);

			var getBookResponse = new GetBookResponse
			{
				Books = result.Select(BookDTOFactory.FromBook).ToList()
			};

			return Ok(ResponseFactory.WithSuccess(getBookResponse));
		}
	}
}
