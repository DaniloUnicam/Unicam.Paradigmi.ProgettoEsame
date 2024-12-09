using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Unicam.Paradigmi.Application.Options;
using Unicam.Paradigmi.Web.Results;

namespace Unicam.Paradigmi.Web.Extensions
{
	public static class WebServicesExtensions
	{
		public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllers().ConfigureApiBehaviorOptions(options =>
			{
				options.InvalidModelStateResponseFactory = (context) =>
				{
					return new BadRequestResultFactory(context);
				};
			});

			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddSwaggerConfig();
			// Auto Validation
			//services.AddFluentValidationAutoValidation();

			services.AddJwtAuthentication(configuration);

			services.AddOptions(configuration);

			// Serialization limit (max. 32) to not cause loops
			services.AddJsonSerializationDepthLimit();

			return services;
		}

		private static IServiceCollection AddJsonSerializationDepthLimit(this IServiceCollection services)
		{
			services.AddControllers()
				.AddJsonOptions(option =>
				{
					option.JsonSerializerOptions.MaxDepth = 32;
				});
			return services;
		}

		private static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Unicam_Paradigmi_Project_App",
					Version = "v1"
				});
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement {
		{
			new OpenApiSecurityScheme {
				Reference = new OpenApiReference {
					Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
				}
			},
			new string[] {}
		}
	});
			});
			return services;
		}

		private static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			var jwtAuthentication = new JwtAuthenticationOption();
			configuration.GetSection("JwtAuthentication").Bind(jwtAuthentication);

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
				(options =>
				{
					string key = jwtAuthentication.Key;
					var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
					options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateLifetime = true,
						ValidateAudience = false,
						ValidateIssuerSigningKey = true,
						ValidIssuer = jwtAuthentication.Issuer,
						IssuerSigningKey = securityKey
					};
				});
			return services;
		}

		private static void AddOptions(this IServiceCollection services, IConfiguration configuration)
		{
			//la configurazione email all'interno di appsettings, posso leggerla
			//in questa maniera:
			//i : dopo emailoption sono un separatore per andare a leggere il valore nel json
			//questa configurazione la possiamo iniettare in qualsiasi oggetto
			string host = configuration.GetValue<string>("EmailOption:Host");
			//qui prendo un array di stringhe presente all'interno del file json
			string[] tos = configuration.GetValue<string[]>("EmailOption:Tos");

			//posso iniettare la configurazione email in un oggetto EmailOption
			var emailOption = new EmailOption();

			configuration.GetSection("EmailOption").Bind(emailOption);

			//se avessi la necessità di implementare emailoption su 4-5 classi, dovrò fare l'iniezione
			//di dipendenza in tutte le classi, quindi è meglio fare l'iniezione di dipendenza
			services.Configure<EmailOption>(
				configuration.GetSection("EmailOption"));

			services.Configure<JwtAuthenticationOption>(
				configuration.GetSection("JwtAuthentication")
				);
		}


	}
}
