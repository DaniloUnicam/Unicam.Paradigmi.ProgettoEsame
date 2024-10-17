using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Configurations
{
	public class UtenteConfigurations : IEntityTypeConfiguration<Utente>
	{
		public void Configure(EntityTypeBuilder<Utente> builder)
		{
			builder.ToTable("Utente");
			builder.HasKey(p => p.IdUtente).HasName("p");
		}
	}
}
