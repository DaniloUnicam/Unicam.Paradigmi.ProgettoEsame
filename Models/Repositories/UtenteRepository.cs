using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
	public class UtenteRepository : GenericRepository<Utente>
	{
		public UtenteRepository(MyDbContext ctx) : base(ctx) { }


	}
}
