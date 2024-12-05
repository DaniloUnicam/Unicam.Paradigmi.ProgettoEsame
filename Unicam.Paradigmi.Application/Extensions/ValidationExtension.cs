using FluentValidation;
using System.Text.RegularExpressions;

namespace Unicam.Paradigmi.Application.Extensions
{
	public static class ValidationExtension
	{
		public static void ValidateRegularExpression<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string regex, string validationMessage)
		{
			ruleBuilder.Custom((value, context) =>
			{
				var regexp = new Regex(regex);
				if (!regexp.IsMatch(value.ToString()))
				{
					context.AddFailure("Password field must be at least 8 characters long," +
						"must contain an upper case character," +
						"a lower case character" +
						"and a special character");
				}
			});
		}

		//RFC 5321, RFC 5322
		//EmailAddress checks if the email contains @ and has a correct site domain
		//Doesn't value if the email exists
		public static IRuleBuilderOptions<T, string> ValidateEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder
				.MinimumLength(6).WithMessage("Email field must be at least 6 characters long")
				.EmailAddress().WithMessage("Email field must contain a valid Email address, having also at maximum one of this character '@'.");
		}



		public static void ValidateCollection<T, TProperty>(
			this IRuleBuilderInitial<T, ICollection<TProperty>> ruleBuilderOptions,
			Predicate<TProperty> predicate,
			string validationMessage)
		{
			ruleBuilderOptions.Custom((value, context) =>
			{
				if (!value.All(predicate.Invoke)) context.AddFailure(validationMessage);
			});
		}

		public static IRuleBuilderOptions<T, TProperty> NotNullOrEmpty<T, TProperty>(
		this IRuleBuilder<T, TProperty> ruleBuilder, string fieldName)
		{
			return ruleBuilder
				.NotEmpty().WithMessage($"{fieldName} field can't be left empty")
				.NotNull().WithMessage($"{fieldName} field can't be inexistent");
		}
	}
}
