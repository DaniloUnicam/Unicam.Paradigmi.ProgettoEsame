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
	[AllowAnonymous]
	[Route("api/v1/[controller]")]
	public class UserController : ControllerBase
	{
		public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

		[HttpPost]
		[Route("create")]
        public async Task<IActionResult> CreateUserAsync(CreateUserRequest request)
		{
			var validateCreatingUser = new CreateUserRequestValidator();
			validateCreatingUser.Validate(request);

			var user = request.ToEntity();

			var createUserResult = await _userService.CreateUserAsync(user);

			var createUserResponse = new CreateUserResponse
			{
				UserDTO = new UserDTO(createUserResult)
			};
			return Ok(ResponseFactory.WithSuccess(createUserResponse));
		}



	}
}
