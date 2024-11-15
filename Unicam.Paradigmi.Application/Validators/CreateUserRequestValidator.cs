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
            RuleFor(n => n.Nome)
                .NotEmpty()
                .WithMessage("Il campo Nome non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Nome non può essere nullo");

            RuleFor(c => c.Cognome)
				.NotEmpty()
				.WithMessage("Il campo Cognome non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Cognome non può essere nullo");

            RuleFor(e => e.Email)
				.NotEmpty()
				.WithMessage("Il campo Email non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Email non può essere nullo")
				.MinimumLength(4)
				.EmailAddress()
				.WithMessage("Il campo Email deve contenere un indirizzo email valido");

			RuleFor(p => p.Password)
				.NotEmpty()
				.WithMessage("Il campo Password non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Password non può essere nullo")
				.MinimumLength(8)
				.WithMessage("Il campo Password deve essere lungo almeno 8 caratteri")
				.RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\W).{6,}$\r\n",
				"Il campo password deve essere lungo almeno 6 caratteri," +
				" deve contenere un carattere maiuscolo, " +
				"un carattere minuscolo e un carattere speciale");
		}

    }
}
