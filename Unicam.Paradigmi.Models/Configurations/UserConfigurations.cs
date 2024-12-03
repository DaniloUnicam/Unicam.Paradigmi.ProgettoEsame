﻿using Microsoft.EntityFrameworkCore;
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
			builder.ToTable("Users")
				.HasKey(p => p.UserId);

			builder.Property(u => u.Name)
				.IsRequired()
				.HasMaxLength(11);

			builder.Property(u => u.Surname)
				.IsRequired()
				.HasMaxLength(11);

			builder.Property(u => u.Email)
				.IsRequired()
				.HasMaxLength(11);

			builder.Property(u => u.Password)
				.IsRequired()
				.HasMaxLength(11);

		}
	}
}
