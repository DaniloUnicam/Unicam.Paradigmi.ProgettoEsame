using System.Collections.ObjectModel;
using Unicam.Paradigmi.Application.Abstractions.Generics;

namespace Unicam.Paradigmi.Models.Entities
{

	public class Book : INamedEntity
	{
		public Book()
		{
			CategoryName = string.Empty;
			Author = string.Empty;
			PublishDate = new DateTime();
			Editor = string.Empty;
			Categories = new List<BookCategory>();
		}

		public int IdBook { get; set; }

		public string CategoryName { get; set; }

		public string Author { get; set; }

		public DateTime? PublishDate { get; set; }

		public string Editor { get; set; }

		public List<BookCategory> Categories { get; set; }
	}
}
