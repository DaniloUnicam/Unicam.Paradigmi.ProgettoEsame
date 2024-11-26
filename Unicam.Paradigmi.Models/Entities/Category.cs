﻿using Unicam.Paradigmi.Application.Abstractions.Generics;

namespace Unicam.Paradigmi.Models.Entities
{
	public class Category : INamedEntity
	{
        public string BookTitle { get; set; } = string.Empty;

		public int IdCategory { get; set; }

	}
}