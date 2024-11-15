using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Validators
{
	public class DeleteCategoriaRequestValidator : AbstractValidator<DeleteCategoriaRequest>
	{
		private readonly CategoriaService _categoriaService;

        public DeleteCategoriaRequestValidator()
        {
			RuleFor(n => n.Nome)
				.NotEmpty()
				.WithMessage("Il campo Nome non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Nome non può essere nullo")
				.Must(nome => _categoriaService.CategoriaVuota(nome))
				.WithMessage("La categoria appartiene ad uno o più libri");

		}
    }
}
