using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
	{
		public CreateBookRequestValidator()
		{
			RuleFor(n => n.Nome)
				.NotEmpty()
				.WithMessage("Il campo Nome non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Nome non può essere nullo");

			RuleFor(a => a.Autore)
				.NotEmpty()
				.WithMessage("Il campo Autore non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Autore non può essere nullo");

			RuleFor(d => d.DataDiPubblicazione)
				.NotEmpty()
				.WithMessage("Il campo DataDiPubblicazione non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo DataDiPubblicazione non può essere nullo")
				.LessThanOrEqualTo(DateTime.Now)
				.WithMessage("Il campo DataDiPubblicazione deve contenere una data riferita al passato o attuale, non futura");

			RuleFor(e => e.Editore)
				.NotEmpty()
				.WithMessage("Il campo Editore non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Editore non può essere nullo");
		}
	}
}
