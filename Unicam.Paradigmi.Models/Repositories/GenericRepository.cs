using Microsoft.EntityFrameworkCore;
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


		public T GetEntity(T entity) => entity != null ?
			_ctx.Set<T>().Find(entity) : throw new NullReferenceException("Id sconosciuto");

		public List<T> GetAllEntitiesAsList() => _ctx.Set<T>().ToList();
		public bool ContainsEntity(T entity)
		{
			return _ctx.Set<T>().Any(e => e.Equals(entity));
		}
		public bool ContainsName(string entity)
		{
			return _ctx.Set<T>().Any(e => e.Equals(entity));
		}

		/***
		 * Ritorna true se il nome della categoria esiste ed appartiene ad un libro, altrimenti false.
		 * @param nomeCategoria
		 */
		public bool EmptyCategory(string categoryName)
		{
			return _ctx.Books.Any(l => l.Categories.Any(c => c.Nome == categoryName));
		}

		public void Delete(T id)
		{
			var entity = this.GetEntity(id);
			_ctx.Entry(entity).State = EntityState.Deleted;
		}

		public void Save() => _ctx.SaveChanges();


	}
}
