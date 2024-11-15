using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Application.Factories
{
	public class ResponseFactory
	{
		public static BaseResponse<T> WithSuccess<T>(T result)
		{
			var response = new BaseResponse<T>
			{
				Success = true,
				Result = result
			};
			return response;
		}

		public static BaseResponse<T> WithError<T>(T result)
		{
			var response = new BaseResponse<T>
			{
				Success = false,
				Result = result
			};
			return response;
		}

		public static BaseResponse<string> WithError(Exception exception)
		{
			var response = new BaseResponse<string>
			{
				Success = false,
				Errors = new List<string>()
			{
				exception.Message
			}
			};
			return response;
		}
	}
}

