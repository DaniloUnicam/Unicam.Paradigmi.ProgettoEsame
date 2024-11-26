using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Extensions;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
	{
        public CreateTokenRequestValidator()
        {

			RuleFor(u => u.Password)
				.NotEmpty().WithMessage("password field can't be left empty");
			RuleFor(u => u.Email)
				.ValidateEmail();
		}
	}
}
