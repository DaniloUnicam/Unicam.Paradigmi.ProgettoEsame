using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
	public class LibroDTO
    {
        public LibroDTO() { }
		public LibroDTO(Libro libro)
        {
			Id = libro.IdLibro;
			Nome = libro.Nome;
			Autore = libro.Autore;
			DataPubblicazione = libro.DataDiPubblicazione;
			Editore = libro.Editore;

		}

		public int Id { get; set; }

		public string Nome { get; set; } = string.Empty;

		public string Autore { get; set; } = string.Empty;

		public DateTime DataPubblicazione { get; set; } = new DateTime();

		public string Editore { get; set; } = string.Empty;


	}

}
