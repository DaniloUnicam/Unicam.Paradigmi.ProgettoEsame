using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Models.Extensions;
using Unicam.Paradigmi.Web.Extensions;

namespace Unicam.Paradigmi.ProgettoEsame
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services

			builder.Services.AddApplicationServices(builder.Configuration)
				.AddModelServices(builder.Configuration)
				.AddWebServices(builder.Configuration);

			var app = builder.Build();

			// Add Middlewares

			app.AddWebMiddleware();


			app.Run();
		}
	}
}
