using System.Collections.ObjectModel;

namespace Unicam.Paradigmi.Models.Entities
{

	public class Book
	{
		public Book()
		{
			Nome = string.Empty;
			Autore = string.Empty;
			DataDiPubblicazione = new DateTime();
			Editore = string.Empty;
			Categories = new Collection<Category>();
		}

		public int IdLibro { get; set; }

		public string Nome { get; set; }

		public string Autore { get; set; }

		public DateTime DataDiPubblicazione { get; set; }

		public string Editore { get; set; }

		public ICollection<Category> Categories { get; set; }
	}
}
