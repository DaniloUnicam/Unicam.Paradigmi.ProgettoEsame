using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
	{
        public CreateUserRequestValidator()
        {
            RuleFor(n => n.Name)
				.NotEmpty().WithMessage("Name field can't be left empty")
				.NotNull().WithMessage("Name field can't be inexistent");

			RuleFor(c => c.Surname)
				.NotEmpty().WithMessage("Surname field can't be left empty")
				.NotNull().WithMessage("Password field can't be inexistent");

			RuleFor(e => e.Email)
				.NotEmpty().WithMessage("Email field can't be left empty")
				.NotNull().WithMessage("Email field can't be inexistent")
				//RFC 5321, RFC 5322
				.MinimumLength(6).WithMessage("Email field must be at least 6 characters long")
				.EmailAddress().WithMessage("Email field must contain a valid Email address," +
				" having also at maxinum one of this character '@'.");

			RuleFor(p => p.Password)
				.NotEmpty().WithMessage("Password field can't be left empty")
				.NotNull().WithMessage("Password field can't be left empty")
				.MinimumLength(8).WithMessage("Il campo Password deve essere lungo almeno 8 caratteri")
				.RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\W).{6,}$\r\n",
				"Il campo password deve essere lungo almeno 6 caratteri," +
				" deve contenere un carattere maiuscolo, " +
				"un carattere minuscolo e un carattere speciale");
		}

    }
}
