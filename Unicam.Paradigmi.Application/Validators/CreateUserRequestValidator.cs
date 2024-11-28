using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Bookshop.Application.Extensions;

namespace Unicam.Paradigmi.Application.Validators
{
	public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
	{
        public CreateUserRequestValidator()
        {
			RuleFor(u => u.Password)
			.NotNull().WithMessage("Password's field can't be null")
			.NotEmpty().WithMessage("Password's field can't be empty")
			.MinimumLength(6)
			.RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\W).{6,}$\r\n",
				"The password field must:" +
				"1) be at least 6 characters long" +
				"2) contain an upper case character" +
				"3) contain a lower case character" +
				"4) contain a special character"); ;
			RuleFor(u => u.Email)
				.ValidateEmail();
			RuleFor(u => u.Name)
				.NotEmpty().WithMessage("Name field can't be empty");
			RuleFor(u => u.Surname)
				.NotEmpty().WithMessage("Surname field can't be empty");
		}

    }
}
