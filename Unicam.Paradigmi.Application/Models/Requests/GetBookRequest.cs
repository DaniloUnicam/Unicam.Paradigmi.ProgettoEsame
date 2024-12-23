﻿using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class GetBookRequest
	{
		public int Page { get; set; }
		public int PageSize { get; set; }


		public string? BookName { get; set; }
		public DateTime? PublicationDate { get; set; }
		public string? Author { get; set; }
		public string? Editor { get; set; }
		public string? CategoryName { get; set; }
	}
}
