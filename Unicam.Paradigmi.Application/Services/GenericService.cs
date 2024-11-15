using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class GenericService<T> where T : class
	{
		private readonly GenericRepository<T> _repository;

		public GenericService(GenericRepository<T> genericRepository)
			=> _repository = genericRepository;

		public List<T> OttieniTutti() => _repository.OttieniTutti();

		public void AddEntita(T entita)
		{
			verificaNull(entita);
			_repository.Aggiungi(entita);
			_repository.Save();
		}

		public T Ottieni(T id) => _repository.Ottieni(id);

		public void Modifica(T entity)
		{
			verificaNull(entity);
			_repository.Modifica(entity);
		}

		public void Elimina(T entity)
		{
			verificaNull(entity);
			_repository.Elimina(entity);
		}

		public bool Contiene(T entity)
		{
			verificaNull(entity);
			return _repository.Contiene(entity);
		}

		public bool ContieneNome(string entity)
		{
			return _repository.ContieneNome(entity); 
		}

		public bool CategoriaVuota(string nomeCategoria)
		{
			return _repository.CategoriaVuota(nomeCategoria);
		}

		public void Salva() => _repository.Save();

		private void verificaNull(T entita)
		{
			if (entita == null)
			{
				throw new ArgumentNullException("Entità inserita nulla");
			}
		}
	}
}


