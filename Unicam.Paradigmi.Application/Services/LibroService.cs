using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class LibroService : GenericService<Libro>, ILibroService
	{

		public LibroService(LibroRepository libroRepository) : base(libroRepository)
		{

		}

		public Categoria OttieniCategoria(int IdLibro, string categoria)
		{
			var libro = base.Ottieni(IdLibro);
			return libro.Categorie.FirstOrDefault(c => c.Equals(categoria));
		}

		public List<Categoria> OttieniCategorie(int IdLibro)
		{
			var libro = base.Ottieni(IdLibro);
			return libro.Categorie.ToList();
		}

	}


}
