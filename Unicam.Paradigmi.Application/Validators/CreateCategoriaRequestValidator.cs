using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateCategoriaRequestValidator : AbstractValidator<CreateCategoriaRequest>
	{
		private readonly CategoriaService _categoriaService;
		public CreateCategoriaRequestValidator()
		{
			RuleFor(n => n.Nome)
				.NotEmpty()
				.WithMessage("Il campo Nome non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Nome non può essere nullo")
				.Must(_categoriaService.ContieneNome)
				.WithMessage("Il campo Nome è già esistente");
		}

	}
}
