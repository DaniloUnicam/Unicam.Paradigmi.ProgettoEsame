using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class CreateCategoriaRequest
	{
		public string Nome { get; set; } = string.Empty;

		public Categoria ToEntity()
		{
			var categoria = new Categoria
			{
				Nome = Nome
			};
			return categoria;
		}
	}
}
