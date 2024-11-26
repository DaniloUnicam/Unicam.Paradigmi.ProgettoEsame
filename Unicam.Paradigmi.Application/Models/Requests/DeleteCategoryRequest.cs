﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class DeleteCategoryRequest
	{
		[Required(ErrorMessage = "Il nome è obbligatorio")]
		[MinLength(1)]
		[MaxLength(25)]
		public string Nome { get; set; } = string.Empty;

		public Category ToEntity()
		{
			var category = new Category()
			{
				BookTitle = Nome
			};
			return category;
		}

	}
}