using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
	public class BookRepository : GenericRepository<Book>
	{

		public BookRepository(MyDbContext ctx) : base(ctx) { }


	}
}
