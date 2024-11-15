using System.ComponentModel.DataAnnotations;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class CreateUtenteRequest
	{
		[Required(ErrorMessage = "Il nome è obbligatorio")]
		[MinLength(1)]
		[MaxLength(25)]
		public string Nome { get; set; } = string.Empty;
		[Required(ErrorMessage = "Il cognome è obbligatorio")]
		[MinLength(1)]
		[MaxLength(25)]
		public string Cognome { get; set; } = string.Empty;
		[Required(ErrorMessage = "La email è obbligatoria")]
		[MinLength(4)]
		[MaxLength(25)]
		public string Email { get; set; } = string.Empty;
		[Required(ErrorMessage = "La password è obbligatoria")]
		[MinLength(8)]
		[MaxLength(25)]
		public string Password { get; set; } = string.Empty;


		public Utente ToEntity()
		{
			var utente = new Utente
			{
				Email = Email,
				Nome = Nome,
				Cognome = Cognome,
				Password = Password
			};
			return utente;
		}
	}
}
