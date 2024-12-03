using FluentValidation;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
	{
		public CreateCategoryRequestValidator()
		{
			RuleFor(n => n.Name)
				.NotNullOrEmpty("Name");
		}

	}
}
