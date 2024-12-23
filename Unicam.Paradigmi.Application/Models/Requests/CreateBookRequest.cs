﻿using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class CreateBookRequest
	{
		public string BookTitle { get; set; } = string.Empty;

		public string Author { get; set; } = string.Empty;

		public DateTime PublicationDate { get; set; } = new DateTime();

		public string Editor { get; set; } = string.Empty;
		public ICollection<int> CategoriesId { get; set; } = new List<int>();

		public virtual Book ToEntity()
		{
			var book = new Book
			{
				BookName = BookTitle,
				Author = Author,
				PublishDate = PublicationDate,
				Editor = Editor
			};
			return book;
		}
	}
}
