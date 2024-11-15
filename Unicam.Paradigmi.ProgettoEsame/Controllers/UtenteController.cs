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
	public class UtenteController : ControllerBase
	{
		public readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            this._utenteService = utenteService;
        }

		[HttpGet]
		[Route("create")]
        public async Task<IActionResult> CreaUtente(CreateUtenteRequest request)
		{
			var utenteValidator = new CreateUtenteRequestValidator();
			utenteValidator.Validate(request);
			var utente = request.ToEntity();
			await _utenteService.AddUtenteAsync(utente);

			var response = new CreateUtenteResponse
			{
				Utente = new UtenteDTO(utente)
			};
			return Ok(ResponseFactory.WithSuccess(response));
		}
	}
}
