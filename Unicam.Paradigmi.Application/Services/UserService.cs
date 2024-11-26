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
	public class UserService : IUserService
	{
		public readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
			_userRepository = userRepository;
        }

		public async Task AddUserAsync(User user)
		{
			_userRepository.AddEntity(user);
			await _userRepository.SaveChangesAsync();
		}
	}
}
