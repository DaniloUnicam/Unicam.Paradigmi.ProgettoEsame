﻿using Unicam.Paradigmi.Application.Abstractions.Services;
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

		public async Task<User> CreateUserAsync(User user)
		{
			var emailAlreadyExists = await _userRepository.EmailExistsInDatabaseAsync(user.Email);
			if (emailAlreadyExists)
			{
				throw new InvalidOperationException($"{user.Email} already exists");
			}

			_userRepository.AddEntity(user);
			await _userRepository.SaveChangesAsync();
			return user;
		}
	}
}
