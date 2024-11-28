using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Results
{
	public class BadRequestResultFactory : BadRequestObjectResult
	{
		public BadRequestResultFactory(ActionContext context) : base(new BadResponse())
		{
			var retErrors = new List<string>();
			foreach (var key in context.ModelState)
			{
				var error = key.Value.Errors;
				for (var i = 0; i < error.Count; i++)
				{
					retErrors.Add(error[0].ErrorMessage);
				}
			}
			var response = (BadResponse?)Value;
			response.Errors = retErrors;
		}
	}
}
