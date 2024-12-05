using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class CreateUserRequest
	{
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;


		public User ToEntity()
		{
			var user = new User
			{
				Email = Email,
				Name = Name,
				Surname = Surname,
				Password = Password
			};
			return user;
		}
	}
}
