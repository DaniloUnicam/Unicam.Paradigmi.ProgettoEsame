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
	public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
	{
		public void Configure(EntityTypeBuilder<Categoria> builder)
		{
			builder.ToTable("Categoria");
			builder.HasKey(id => id.Nome).HasName("Nome");
		}
	}
}
