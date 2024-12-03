using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
