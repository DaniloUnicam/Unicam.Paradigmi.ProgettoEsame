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
	public class UserController : ControllerBase
	{
		public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

		[HttpGet]
		[Route("create")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
		{
			var userValidator = new CreateUserRequestValidator();
			userValidator.Validate(request);
			var user = request.ToEntity();
			await _userService.AddUserAsync(user);

			var response = new CreateUserResponse
			{
				User = new UserDTO(user)
			};
			return Ok(ResponseFactory.WithSuccess(response));
		}
	}
}
