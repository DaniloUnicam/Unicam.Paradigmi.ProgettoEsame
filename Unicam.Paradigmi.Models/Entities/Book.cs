namespace Unicam.Paradigmi.Models.Entities
{

	public class Book
	{
		public Book()
		{
			BookName = string.Empty;
			Author = string.Empty;
			PublishDate = new DateTime();
			Editor = string.Empty;
			Categories = new List<BookCategory>();
		}

		public int IdBook { get; set; }

		public string BookName { get; set; }

		public string Author { get; set; }

		public DateTime? PublishDate { get; set; }

		public string Editor { get; set; }

		public List<BookCategory> Categories { get; set; }
	}
}
