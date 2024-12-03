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
				.NotNullOrEmpty("Password")
				.MinimumLength(8).WithMessage("Il campo Password deve essere lungo almeno 8 caratteri")
				.ValidateRegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\W).{6,}$\r\n",
				"Il campo password deve essere lungo almeno 6 caratteri," +
				" deve contenere un carattere maiuscolo, " +
				"un carattere minuscolo e un carattere speciale");

			RuleFor(u => u.Email)
				.NotEmpty().WithMessage("Email field can't be left empty")
				.NotNull().WithMessage("Email field can't be inexistent")
				.ValidateEmail();
		}
	}
}
