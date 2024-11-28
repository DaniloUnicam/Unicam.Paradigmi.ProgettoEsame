﻿using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class UpdateBookRequest
	{

		public int Id { get; set; }

		public string BookTitle { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
		public DateTime? PublicationDate { get; set; }
		public string Editor { get; set; } = string.Empty;
		public ICollection<int> CategoryIds { get; set; } = new List<int>();

		public BookDTO ToDto()
		{
			var bookDto = new BookDTO
			{
				IdBook = Id,
				BookTitle = BookTitle,
				Author = Author,
				PublicationDate = PublicationDate,
				Editor = Editor
			};
			return bookDto;
		}

		public Book ToEntity()
		{
			var book = new Book();
			book.IdBook = Id;
			if (BookTitle != null) book.Title = BookTitle;

			if (Author != null) book.Author = Author;

			if (PublicationDate != null) book.PublishDate = PublicationDate;

			if (Editor != null) book.Editor = Editor;

			return book;
		}
	}
}
