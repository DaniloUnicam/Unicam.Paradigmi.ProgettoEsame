using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Application.Validators;
namespace Unicam.Paradigmi.Web.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class TokenController : ControllerBase
	{
		public readonly ITokenService _tokenService;

		public TokenController(ITokenService tokenService)
		{
			_tokenService = tokenService;
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateTokenAsync(CreateTokenRequest tokenRequest)
		{
			var createTokenValidator = new CreateTokenRequestValidator();
			createTokenValidator.Validate(tokenRequest);

			var Token = await _tokenService.CreateTokenStringAsync(tokenRequest.Email, tokenRequest.Password);

			var createTokenResponse = new CreateTokenResponse
			{
				TokenResponse = Token
			};

			return Ok(ResponseFactory.WithSuccess(createTokenResponse));
		}

	}
}
