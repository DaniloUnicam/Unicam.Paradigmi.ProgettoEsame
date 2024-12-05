using FluentValidation;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
	{
		public CreateUserRequestValidator()
		{
			RuleFor(n => n.Name)
				.NotNullOrEmpty("Name");

			RuleFor(c => c.Surname)
				.NotNullOrEmpty("Surname");

			RuleFor(e => e.Email)
				.NotNullOrEmpty("Email")
				.ValidateEmail();



			RuleFor(p => p.Password)
				.NotNullOrEmpty("Password")
				.MinimumLength(8).WithMessage("The password field must contain at least 8 characters")
				.ValidateRegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\W).{8,}$\r\n",
				"The password field must contain at least one upper case character," +
				"a lower case character and a special character.");
		}

	}
}
