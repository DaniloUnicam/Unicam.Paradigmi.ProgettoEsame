using System.ComponentModel.DataAnnotations;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class CreateUserRequest
	{
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;


		public virtual User ToEntity()
		{
			var user = new User
			{
				Username = Name,
				Surname = Surname,
				Email = Email,
				Password = Password
			};
			return user;
		}
	}
}
