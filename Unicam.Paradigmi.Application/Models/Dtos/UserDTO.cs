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
            Id = user.IdUtente;
            Nome = user.Nome;
            Cognome = user.Cognome;
			Email = user.Email;
			Password = user.Password;
		}

        public int Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string Cognome { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
