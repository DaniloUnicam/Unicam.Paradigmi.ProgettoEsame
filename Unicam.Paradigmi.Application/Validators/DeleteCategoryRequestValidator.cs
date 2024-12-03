using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Validators
{
	public class DeleteCategoryRequestValidator : AbstractValidator<DeleteCategoryRequest>
	{

        public DeleteCategoryRequestValidator()
        {
			RuleFor(n => n.IdCategory)
				.GreaterThanOrEqualTo(0).WithMessage("Wrong Id format");
		}
    }
}
