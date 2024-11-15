using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Configurations;
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

		public DbSet<Book> Books { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Category> Categories { get; set; }

		/**
		 * Il context si occuperà della connessione al database
		 */

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.
				UseSqlServer("data source=localhost;Initial catalog= paradigmi;User Id=paradigmi;Password=paradigmi;");
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
