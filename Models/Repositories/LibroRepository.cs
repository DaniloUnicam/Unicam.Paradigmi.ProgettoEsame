using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
	public class LibroRepository : GenericRepository<Libro>
	{

		public LibroRepository(MyDbContext ctx) : base(ctx) { }


	}
}
