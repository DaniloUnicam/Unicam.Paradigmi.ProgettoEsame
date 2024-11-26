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
			IdBook = book.IdBook;
			BookTitle = book.BookTitle;
			Author = book.Author;
			PublicationDate = book.PublishDate;
			Editor = book.Editor;

		}

		public int IdBook { get; set; }

		public string BookTitle { get; set; } = string.Empty;

		public string Author { get; set; } = string.Empty;

		public DateTime PublicationDate { get; set; }

		public string Editor { get; set; } = string.Empty;


	}

}
