using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Application.Options
{
	public class EmailOption
	{
		public string TenantId { get; set; } = string.Empty;
		public string ClientId { get; set; } = string.Empty;
		public string ClientSecret { get; set; } = string.Empty;
		public string From { get; set; } = string.Empty;
		public List<string> Tos { get; set; } = null!;
	}
}
