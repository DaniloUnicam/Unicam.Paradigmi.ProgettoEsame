using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class UtenteService : GenericService<Utente>, IUtenteService
	{
        public UtenteService(UtenteRepository utenteRepository) : base(utenteRepository)
        {
            
        }
    }
}
