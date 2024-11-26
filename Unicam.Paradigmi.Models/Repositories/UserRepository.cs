using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
	public class UserRepository : GenericRepository<User>
	{
		public UserRepository(MyDbContext ctx) : base(ctx) { }

		public async Task<bool> EmailExistsInDatabaseAsync(string email)
		{
			return await _ctx.Users.AnyAsync(q => q.Email.Equals(email));
		}

		public async Task<User?> GetUserFromEmailAndPassword(string email, string password)
		{
			return await _ctx.Users.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
		}
	}

}
