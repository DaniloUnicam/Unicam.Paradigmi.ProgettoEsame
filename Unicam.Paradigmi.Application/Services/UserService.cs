using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class UserService : GenericService<User>, IUserService
	{
        public UserService(UserRepository userRepository) : base(userRepository)
        {
            
        }

		public async Task AddUserAsync(User user)
		{
			base.AddEntity(user);
			base.Save();
		}
	}
}
