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
	public class LibroConfigurations : IEntityTypeConfiguration<Libro>
	{
		public void Configure(EntityTypeBuilder<Libro> builder)
		{
			builder.ToTable("Libro");
			builder.HasKey(id => id.IdLibro).HasName("id");
		}
	}
}
