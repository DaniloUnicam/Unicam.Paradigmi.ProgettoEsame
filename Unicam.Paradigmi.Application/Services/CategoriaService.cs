using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class CategoriaService : GenericService<Categoria>, ICategoriaService
	{

		public CategoriaService(CategoriaRepository categoriaRepository) : base(categoriaRepository)
        {
            
        }

		public async Task AddCategoriaAsync(Categoria categoria)
		{
			base.AddEntita(categoria);
			base.Salva();
		}

		public async Task DeleteCategoriaAsync(Categoria categoria)
		{
			base.Elimina(categoria);
			base.Salva();
		}
	}
}
