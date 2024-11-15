using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
	public class UserRepository : GenericRepository<User>
	{
		public UserRepository(MyDbContext ctx) : base(ctx) { }


	}
}
