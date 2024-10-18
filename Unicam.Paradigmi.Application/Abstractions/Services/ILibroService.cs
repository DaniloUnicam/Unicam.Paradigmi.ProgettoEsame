using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface ILibroService
	{
		public Categoria OttieniCategoria(int IdLibro,string categoria);

		public List<Categoria> OttieniCategorie(int IdLibro);
	}
}
