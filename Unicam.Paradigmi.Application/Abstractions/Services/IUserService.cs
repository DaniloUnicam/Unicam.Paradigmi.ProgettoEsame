using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface IUserService
	{
		Task<User> CreateUserAsync(User user);
	}
}
