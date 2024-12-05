using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
	public class BookDTO
	{
		public BookDTO() { }
		public BookDTO(Book book)
		{
			IdBook = book.IdBook;
			BookTitle = book.BookName;
			Author = book.Author;
			PublicationDate = book.PublishDate;
			Editor = book.Editor;
		}

		public int IdBook { get; set; }

		public string BookTitle { get; set; } = string.Empty;

		public string Author { get; set; } = string.Empty;

		public DateTime? PublicationDate { get; set; }

		public string Editor { get; set; } = string.Empty;

		public ICollection<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

	}

}
