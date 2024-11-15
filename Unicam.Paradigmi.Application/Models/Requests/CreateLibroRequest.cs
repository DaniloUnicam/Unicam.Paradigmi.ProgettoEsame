using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class CreateLibroRequest
	{
		public string Nome { get; set; } = string.Empty;

		public string Autore { get; set; } = string.Empty;

		public DateTime DataDiPubblicazione { get; set; } = new DateTime();

		public string Editore { get; set; } = string.Empty;
		public ICollection<Categoria> Categorie { get; set; } = new List<Categoria>();

		public Libro ToEntity()
		{
			var libro = new Libro
			{
				Nome = Nome,
				Autore = Autore,
				DataDiPubblicazione = DataDiPubblicazione,
				Editore = Editore,
				Categorie = Categorie
			};
			return libro;
		}
	}
}
