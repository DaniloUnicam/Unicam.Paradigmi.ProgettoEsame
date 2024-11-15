using System.ComponentModel.DataAnnotations;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class DeleteBookRequest
	{
		[Required(ErrorMessage = "Il nome è obbligatorio")]
		[MinLength(1)]
		[MaxLength(25)]
		public string Nome { get; set; } = string.Empty;

		public Book ToEntity()
		{
			var book = new Book()
			{
				Nome = Nome
			};
			return book;
		}


	}
}
