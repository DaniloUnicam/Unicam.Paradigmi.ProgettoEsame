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
	public class LibroController : ControllerBase
	{
		public readonly ILibroService _libroService;

		public LibroController(ILibroService libroService)
		{
			_libroService = libroService;
		}

		[HttpPost]
		[Route("post")]
		public async Task<IActionResult> CaricaLibro(CreateLibroRequest request)
		{
			var caricaLibroValidator = new CreateLibroRequestValidator();
			caricaLibroValidator.Validate(request);
			var libro = request.ToEntity();
			await _libroService.UploadLibroAsync(libro);

			var response = new CreateLibroResponse
			{
				Libro = new LibroDTO()
			};
			return Ok(ResponseFactory.WithSuccess(response));
		}

		
	}
}
