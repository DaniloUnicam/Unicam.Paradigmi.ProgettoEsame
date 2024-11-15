using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Application.Extensions
{
	public static class ExpressionValidationExtension
	{
		public static void RegEx<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string regex, string validationMessage)
		{
			ruleBuilder.Custom((value, context) =>
			{
				var regexp = new Regex(regex);
				if (!regexp.IsMatch(value.ToString()))
				{
					context.AddFailure("Il campo password deve essere lungo almeno 6 caratteri, deve contenere un carattere maiuscolo, un carattere minuscolo e un carattere speciale");
				}
			});
		}
	}
}
