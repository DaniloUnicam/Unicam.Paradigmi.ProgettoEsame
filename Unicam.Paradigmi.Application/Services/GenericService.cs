using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class GenericService<T> where T : class
	{
		public readonly GenericRepository<T> _repository;

		public GenericService(GenericRepository<T> genericRepository)
			=> _repository = genericRepository;

		public List<T> GetAllEntitiesAsList() => _repository.GetAllEntitiesAsList();

		public void AddEntity(T entity)
		{
			verifyNullEntity(entity);
			_repository.AddEntity(entity);
			_repository.Save();
		}

		public T GetEntity(T entity) => _repository.GetEntity(entity);

		public void ApplyChange(T entity)
		{
			verifyNullEntity(entity);
			_repository.ApplyChange(entity);
		}

		public void Delete(T entity)
		{
			verifyNullEntity(entity);
			_repository.Delete(entity);
		}

		public bool ContainsEntity(T entity)
		{
			verifyNullEntity(entity);
			return _repository.ContainsEntity(entity);
		}

		public bool ContainsName(string entity)
		{
			return _repository.ContainsName(entity);
		}

		public bool EmptyCategory(string nomeCategoria)
		{
			return _repository.EmptyCategory(nomeCategoria);
		}

		public void Save() => _repository.Save();

		private void verifyNullEntity(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("Entità inserita nulla");
			}

		}
	}
}


