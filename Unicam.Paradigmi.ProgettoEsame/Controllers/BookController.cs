using Microsoft.AspNetCore.Authorization;
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
	[Authorize]
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



		[HttpGet]
		[Route("search")]
		public async Task<IActionResult> GetBookAsync(
			[FromQuery] int page,
			[FromQuery] int pageSize,
			[FromQuery] string? categoryName,
			[FromQuery] string? bookName,
			[FromQuery] DateTime? publicationDate,
			[FromQuery] string? author,
			[FromQuery] string? editor)
		{
			var request = new GetBookRequest()
			{
				Page = page,
				PageSize = pageSize,
				CategoryName = categoryName,
				BookName = bookName,
				PublicationDate = publicationDate,
				Author = author,
				Editor = editor
			};

			var getBookValidator = new GetBookRequestValidator();
			getBookValidator.Validate(request);

			try
			{
				var (books, totalCount) = await _bookService.GetBooksByFiltersAsync(
					categoryName, bookName, publicationDate, author, editor, page, pageSize);

				return Ok(new
				{
					TotalCount = totalCount,
					Page = page,
					PageSize = pageSize,
					Books = books
				});
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
