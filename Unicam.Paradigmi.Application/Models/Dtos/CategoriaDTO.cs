using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
	public class CategoriaDTO
	{
        public CategoriaDTO()
        {
 
        }

        public CategoriaDTO(Categoria categoria)
        {
            Nome = categoria.Nome;
        }

        public string Nome { get; set; } = string.Empty;
    }
}
