using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Models.Extensions
{
	public static class ModelServicesExtensions
	{
		public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration iConfiguration)
		{
			services.AddDbContext<MyDbContext>(dbConfig =>
			{
				dbConfig.UseSqlServer(iConfiguration.GetConnectionString("MyDbContext"));
			});

			services.AddScoped<BookCategoryRepository>();
			services.AddScoped<BookRepository>();
			services.AddScoped<CategoryRepository>();
			services.AddScoped<UserRepository>();

			return services;
		}

	}
}
