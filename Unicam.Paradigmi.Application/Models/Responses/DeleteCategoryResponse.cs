﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Models.Dtos;

namespace Unicam.Paradigmi.Application.Models.Responses
{
	public class DeleteCategoryResponse
	{
		public CategoryDTO Category { get; set; } = null!;
	}
}