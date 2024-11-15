using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Responses
{
	public class CreateLibroResponse
	{
		public LibroDTO Libro { get; set; } = null!;
	}
}
