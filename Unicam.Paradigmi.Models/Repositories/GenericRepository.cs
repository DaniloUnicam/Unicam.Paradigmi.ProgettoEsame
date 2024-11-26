using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Application.Abstractions.Generics;
using Unicam.Paradigmi.Models.Context;

namespace Unicam.Paradigmi.Models.Repositories
{
	public abstract class GenericRepository<T> where T : class
	{

		protected MyDbContext _ctx;
		public GenericRepository(MyDbContext ctx)
		{
			_ctx = ctx;
		}

		public void AddEntity(T entity) => _ctx.Set<T>().Add(entity);

		public void ApplyChange(T entity) =>
			_ctx.Entry(entity).State = EntityState.Modified;


		public T GetEntityByName<T>(string entityName) where T : class, INamedEntity
		{
			if(string.IsNullOrEmpty(entityName))
			{
				throw new KeyNotFoundException("Il nome dell'entità non può essere nullo");
			}
			var entity = _ctx.Set<T>().SingleOrDefault(e => e.CategoryName == entityName);
			return entity ?? throw new KeyNotFoundException($"Entità con nome '{entityName}' non trovata");
		}


		public List<T> GetAllEntitiesAsList() => _ctx.Set<T>().ToList();

		public bool ContainsEntity(T entity)
		{
			return _ctx.Set<T>().Any(e => e.Equals(entity));
		}

		
		public void Delete(T entity)
		{
			_ctx.Entry(entity).State = EntityState.Deleted;
		}

		public async Task SaveChangesAsync()
		{
			await _ctx.SaveChangesAsync();
		}

	}
}
