﻿namespace Unicam.Paradigmi.Models.Entities
{
	public class Utente
	{
		public Utente()
		{
			Email = string.Empty;
			Nome = string.Empty;
			Cognome = string.Empty;
			Password = string.Empty;
		}

		public int IdUtente { get; set; }

		public string Email { get; set; }

		public string Nome { get; set; }

		public string Cognome { get; set; }

		public string Password { get; set; }
	}
}
