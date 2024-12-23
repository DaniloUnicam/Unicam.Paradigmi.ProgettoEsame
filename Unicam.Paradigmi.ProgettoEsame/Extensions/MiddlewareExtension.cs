﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using Unicam.Paradigmi.Application.Factories;

namespace Unicam.Paradigmi.Web.Extensions
{
	public static class MiddlewareExtension
	{
		public static WebApplication? AddWebMiddleware(this WebApplication? app)
		{
			if (app == null)
			{
				throw new InvalidOperationException("Can't apply Swagger configurations");
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.Use(async (HttpContext context, Func<Task> next) =>
			{
				await next.Invoke();
			});

			app.UseHttpsRedirection();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						var res = ResponseFactory.WithError(contextFeature.Error);
						await context.Response.WriteAsync(JsonSerializer.Serialize(res));
					}
				});

			});

			app.MapControllers();

			return app;
		}
	}
}

