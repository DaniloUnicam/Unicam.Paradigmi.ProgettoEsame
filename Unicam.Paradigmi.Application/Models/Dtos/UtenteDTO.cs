using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class UtenteDTO
    {
        public UtenteDTO() { }

        public UtenteDTO(Utente utente)
        {
            Id = utente.IdUtente;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
			Email = utente.Email;
			Password = utente.Password;
		}

        public int Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string Cognome { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
