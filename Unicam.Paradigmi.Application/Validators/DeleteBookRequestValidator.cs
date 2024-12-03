using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Validators
{
	public class DeleteBookRequestValidator : AbstractValidator<DeleteBookRequest>
	{

		public DeleteBookRequestValidator()
		{
			RuleFor(n => n.IdBook)
			.GreaterThanOrEqualTo(0).WithMessage("Id must be greater than 0");
		}
	}
}
