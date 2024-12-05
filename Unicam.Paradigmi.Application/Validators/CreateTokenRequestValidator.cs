using FluentValidation;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
	{
		public CreateTokenRequestValidator()
		{

			RuleFor(u => u.Password)
				.NotNullOrEmpty("Password")
				.MinimumLength(8).WithMessage("The password field must contain at least 8 characters")
				.ValidateRegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\W).{8,}$\r\n",
				"The password field must contain at least one upper case character," +
				"a lower case character and a special character.");

			RuleFor(u => u.Email)
				.NotEmpty().WithMessage("Email field can't be left empty")
				.NotNull().WithMessage("Email field can't be inexistent")
				.ValidateEmail();
		}
	}
}
