using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class UserDTO
    {
        public UserDTO() { }

        public UserDTO(User user)
        {
			UserID = user.UserId;
			Username = user.Username;
			Surname = user.Surname;
			Email = user.Email;
			Password = user.Password;
		}

        public int UserID { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
