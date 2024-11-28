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
	public class UserConfigurations : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("User");
			builder.HasKey(p => p.IdUtente).HasName("UserId");

			builder.Property(u => u.Name)
			.IsRequired()
			.HasMaxLength(30);

			builder.Property(u => u.Surname)
				.IsRequired()
				.HasMaxLength(30);

			builder.Property(u => u.Email)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(u => u.Password)
				.IsRequired()
				.HasMaxLength(100);

		}
	}
}
