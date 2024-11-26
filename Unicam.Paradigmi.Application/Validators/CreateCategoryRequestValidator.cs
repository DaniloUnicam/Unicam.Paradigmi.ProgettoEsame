using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
	{
		private readonly CategoryService _categoriaService;
		public CreateCategoryRequestValidator()
		{
			RuleFor(n => n.Name)
				.NotEmpty()
				.WithMessage("Il campo Nome non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Nome non può essere nullo")
				.Must(_categoriaService.ContainsName)
				.WithMessage("Il campo Nome è già esistente");
		}

	}
}
