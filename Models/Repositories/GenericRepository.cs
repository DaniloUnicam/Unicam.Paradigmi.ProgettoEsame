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

		public void Aggiungi(T entity) => _ctx.Set<T>().Add(entity);

		public void Modifica(T entity) =>
			_ctx.Entry(entity).State = EntityState.Modified;


		public T Ottieni(Object id) => id != null ?
			_ctx.Set<T>().Find(id) : throw new NullReferenceException("Id sconosciuto");

		public List<T> OttieniTutti() => _ctx.Set<T>().ToList();

		public void Elimina(Object id)
		{
			var entity = Ottieni(id);
			_ctx.Entry(entity).State = EntityState.Deleted;
		}

		public void Save() => _ctx.SaveChanges();


	}
}
