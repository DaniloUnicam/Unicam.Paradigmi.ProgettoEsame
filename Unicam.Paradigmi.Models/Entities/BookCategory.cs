using System.Text.Json.Serialization;

namespace Unicam.Paradigmi.Models.Entities
{
	public class BookCategory
	{
		public int BookId { get; set; }
		[JsonIgnore]
		public Book? Book { get; set; }
		public int CategoryId { get; set; }
		[JsonIgnore]
		public Category? Category { get; set; }

	}
}
