using FluentValidation;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;
namespace Unicam.Paradigmi.Application.Validators
{
	public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
	{
        public UpdateBookRequestValidator()
        {
			RuleFor(r => r.Id)
			.GreaterThanOrEqualTo(0).WithMessage("Illegal Id format");
			RuleFor(r => r.CategoryIds)
				.ValidateCollection(v => v >= 0, "Invalid category Id format");
		}
    }
}
