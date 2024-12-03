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
				.NotNullOrEmpty("Name");

			RuleFor(c => c.Surname)
				.NotNullOrEmpty("Surname");

			RuleFor(e => e.Email)
				.NotNullOrEmpty("Email")
				.ValidateEmail();
			
				

			RuleFor(p => p.Password)
				.NotNullOrEmpty("Password")
				.MinimumLength(8).WithMessage("Il campo Password deve essere lungo almeno 8 caratteri")
				.ValidateRegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\W).{6,}$\r\n",
				"Il campo password deve essere lungo almeno 6 caratteri," +
				" deve contenere un carattere maiuscolo, " +
				"un carattere minuscolo e un carattere speciale");
		}

    }
}
