using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Context
{
	public class MyDbContext : DbContext
	{
		public MyDbContext()
		{

		}

		public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
		{

		}

		public DbSet<Book> Books { get; set; } = null!;

		public DbSet<User> Users { get; set; } = null!;

		public DbSet<Category> Categories { get; set; } = null!;

		public DbSet<BookCategory> BookCategories { get; set; } = null!;

		/**
		 * Il context si occuperà della connessione al database
		 */

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				string connectionString = "Server=localhost;User ID=paradigmi;Password=password;Database=enterprise;\r\n";
				optionsBuilder.UseSqlServer(connectionString,
					(Action<SqlServerDbContextOptionsBuilder>?)RetryConnectionFailed())
					.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
			}
		}

		private static Action<SqlServerDbContextOptionsBuilder> RetryConnectionFailed()
		{
			return sqlOptions =>
			{
				//debug errore connessione
				sqlOptions.EnableRetryOnFailure
				(
					maxRetryCount: 5, // Numero massimo di tentativi
					maxRetryDelay: TimeSpan.FromSeconds(3), // Ritardo massimo tra i tentativi
					errorNumbersToAdd: null // Numeri di errore SQL da considerare (opzionale)
				);
			};
		}



		/**
		 *  Si occupa di applicare la configurazione a tutte le classi 
		 *  che implementano IEntityTypeConfiguration
		 */
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
