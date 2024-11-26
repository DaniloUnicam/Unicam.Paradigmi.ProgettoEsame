using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Application.Models.Requests
{
	public class GetBookRequest
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
		public string? BookName { get; set; }
		public DateTime? PublicationDate { get; set; }
		public string? Author { get; set; }
	}
}
