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
	public class BookDTO
    {
        public BookDTO() { }
		public BookDTO(Book book)
        {
			Id = book.IdLibro;
			Nome = book.Nome;
			Autore = book.Autore;
			DataPubblicazione = book.DataDiPubblicazione;
			Editore = book.Editore;

		}

		public int Id { get; set; }

		public string Nome { get; set; } = string.Empty;

		public string Autore { get; set; } = string.Empty;

		public DateTime DataPubblicazione { get; set; } = new DateTime();

		public string Editore { get; set; } = string.Empty;


	}

}
