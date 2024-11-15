using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Application.Services;
using Unicam.Paradigmi.Application.Validators;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriaController : ControllerBase
    {
        public readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            this._categoriaService = categoriaService;
        }

        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> CreaCategoria(CreateCategoriaRequest request)
		{
            var categoriaValidator = new CreateCategoriaRequestValidator();
            categoriaValidator.Validate(request);
            var categoria = request.ToEntity();
            await _categoriaService.AddCategoriaAsync(categoria);

			var response = new CreateCategoriaResponse
			{
				Categoria = new CategoriaDTO(categoria)
			};
			return Ok(ResponseFactory.WithSuccess(response));
		}

		[HttpDelete]
		[Route("delete")]
		public async Task<IActionResult> EliminaCategoria(DeleteCategoriaRequest request)
        {
            var categoriaValidator = new DeleteCategoriaRequestValidator();
            categoriaValidator.Validate(request);
            var categoria = request.ToEntity();
            await _categoriaService.DeleteCategoriaAsync(categoria);

            var response = new DeleteCategoriaResponse
            {
                Categoria = new CategoriaDTO()
            };
            return Ok(ResponseFactory.WithSuccess(response));
        }


	}
}
