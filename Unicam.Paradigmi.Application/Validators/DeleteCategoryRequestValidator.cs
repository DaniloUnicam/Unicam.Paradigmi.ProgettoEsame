using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Validators
{
	public class DeleteCategoryRequestValidator : AbstractValidator<DeleteCategoryRequest>
	{
		private readonly CategoryService _categoriaService;

        public DeleteCategoryRequestValidator()
        {
			RuleFor(n => n.Nome)
				.NotEmpty()
				.WithMessage("Il campo Nome non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Nome non può essere nullo")
				.Must(nome => _categoriaService.EmptyCategory(nome))
				.WithMessage("La categoria appartiene ad uno o più libri");

		}
    }
}
