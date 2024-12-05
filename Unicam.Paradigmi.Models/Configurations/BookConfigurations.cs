using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Configurations
{
	public class BookConfigurations : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Books");
			builder.HasKey(id => id.IdBook);

			builder.Property(b => b.BookName)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(b => b.Author)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(b => b.Editor)
				.HasMaxLength(255);
		}
	}
}
