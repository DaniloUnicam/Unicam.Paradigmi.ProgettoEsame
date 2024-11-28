using FluentValidation;
using System.Text.RegularExpressions;

namespace Unicam.Paradigmi.Application.Extensions
{
	public static class ValidationExtension
	{
		public static void RegEx<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string regex, string validationMessage)
		{
			ruleBuilder.Custom((value, context) =>
			{
				var regexp = new Regex(regex);
				if (!regexp.IsMatch(value.ToString()))
				{
					context.AddFailure("Password field must be at least 6 characters long," +
						"must contain an upper case character," +
						"a lower case character" +
						"and a special character");
				}
			});
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

		public static void ValidateEmail<T>(this IRuleBuilderInitial<T, string> ruleBuilderInitial)
		{
			ruleBuilderInitial.NotNull().WithMessage("Email field can't be null")
				.MaximumLength(100).WithMessage("Email field can't exceed the maximum 100 characters")
				.RegEx("[a-zA-Z0-9._-]+@[a-zA-Z0-9]+.[a-z]{2,}", "Incorrect email format");
		}
	}
}
