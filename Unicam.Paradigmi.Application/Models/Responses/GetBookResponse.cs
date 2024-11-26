using Unicam.Paradigmi.Application.Models.Dtos;

namespace Unicam.Paradigmi.Application.Models.Responses
{
	public class GetBookResponse
	{
		public List<BookDTO> Books { get; set; } = new List<BookDTO>();
	}
}
