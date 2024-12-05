using FluentValidation;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validators
{
	public class GetBookRequestValidator : AbstractValidator<GetBookRequest>
	{
		public GetBookRequestValidator()
		{
			RuleFor(r => r.Page)
				.GreaterThanOrEqualTo(0).WithMessage("Illegal number of pages");
			RuleFor(r => r.PageSize)
				.GreaterThanOrEqualTo(0).WithMessage("Illegal page size")
				.NotNullOrEmpty("BookName")
				.NotNullOrEmpty("Author")
				.NotNullOrEmpty("PublicationDate")
				.NotNullOrEmpty("Editor");

		}
	}
}
