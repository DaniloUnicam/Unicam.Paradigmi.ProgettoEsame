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
				.NotEmpty()
				.WithMessage("Book's title field can't be empty")
				.NotNull()
				.WithMessage("Book's title field can't be null");

			RuleFor(a => a.Author)
				.NotEmpty()
				.WithMessage("Author field can't be empty")
				.NotNull()
				.WithMessage("Author field can't be null");

			RuleFor(d => d.PublicationDate)
				.NotEmpty()
				.WithMessage("PublicationDate field can't be empty")
				.NotNull()
				.WithMessage("PublicationDate field can't be null")
				.LessThanOrEqualTo(DateTime.Now)
				.WithMessage("PublicationDate field can't be from a future date");

			RuleFor(e => e.Editor)
				.NotEmpty()
				.WithMessage("Editor field can't be empty")
				.NotNull()
				.WithMessage("Editor field can't be null");

			RuleFor(i => i.CategoriesId)
				.ValidateCollection(v => v >= 0, "Invalid category Id format");
		}
	}
}
