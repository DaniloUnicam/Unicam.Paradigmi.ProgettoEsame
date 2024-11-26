using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				.GreaterThanOrEqualTo(0).WithMessage("Illegal page size");
			RuleFor(r => new { r.PublicationDate, r.Author, r.BookName })
				.Must(t => t.PublicationDate != null || !string.IsNullOrEmpty(t.Author) ||
						   !string.IsNullOrEmpty(t.BookName))
				.WithMessage("At least one of the require fields must be provided");
		}
	}
}
