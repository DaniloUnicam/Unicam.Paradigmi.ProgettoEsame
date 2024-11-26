using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class CreateBookRequest
	{
		public string Nome { get; set; } = string.Empty;

		public string Autore { get; set; } = string.Empty;

		public DateTime DataDiPubblicazione { get; set; } = new DateTime();

		public string Editore { get; set; } = string.Empty;
		public ICollection<int> CategorieId { get; set; } = new List<int>();

		public Book ToEntity()
		{
			var book = new Book
			{
				BookTitle = Nome,
				Author = Autore,
				PublishDate = DataDiPubblicazione,
				Editor = Editore,
				Categories = Categorie
			};
			return book;
		}
	}
}
