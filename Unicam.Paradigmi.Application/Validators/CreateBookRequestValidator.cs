using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Extensions;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
	{
		public CreateBookRequestValidator()
		{
			RuleFor(n => n.BookTitle)
				.NotNullOrEmpty("BookTitle");

			RuleFor(a => a.Author)
				.NotNullOrEmpty("Author");

			RuleFor(d => d.PublicationDate)
				.NotNullOrEmpty("PublicationDate")
				.LessThanOrEqualTo(DateTime.Now)
				.WithMessage("PublicationDate field can't be from a future date");

			RuleFor(e => e.Editor)
				.NotNullOrEmpty("Editor");

			RuleFor(i => i.CategoriesId)
				.ValidateCollection(v => v >= 0, "Invalid category Id format");
		}
	}
}
