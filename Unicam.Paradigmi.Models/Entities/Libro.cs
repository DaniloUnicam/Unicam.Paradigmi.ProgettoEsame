using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Models.Entities { 

	public class Libro
	{
		public Libro() 
		{
			Nome = string.Empty;
			Autore = string.Empty;
			DataDiPubblicazione = new DateTime();
			Editore = string.Empty;
			Categorie = new Collection<Categoria>();
		}

		public int IdLibro { get; set; }

		public string Nome { get; set; }

		public string Autore { get; set; }

		public DateTime DataDiPubblicazione {  get; set; }

		public string Editore { get; set; }

		public ICollection<Categoria> Categorie {  get; set; }
	}
}
