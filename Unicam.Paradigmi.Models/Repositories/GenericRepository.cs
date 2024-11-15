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


		public T Ottieni(T id) => id != null ?
			_ctx.Set<T>().Find(id) : throw new NullReferenceException("Id sconosciuto");

		public List<T> OttieniTutti() => _ctx.Set<T>().ToList();
		public bool Contiene(T entity)
		{
			return _ctx.Set<T>().Any(e => e.Equals(entity));
		}
		public bool ContieneNome(string entity)
		{
			return _ctx.Set<T>().Any(e => e.Equals(entity));
		}

		/***
		 * Ritorna true se il nome della categoria esiste ed appartiene ad un libro, altrimenti false.
		 * @param nomeCategoria
		 */
		public bool CategoriaVuota(string nomeCategoria)
		{
			return _ctx.Libri.Any(l => l.Categorie.Any(c => c.Nome == nomeCategoria));
		}

		public void Elimina(T id)
		{
			var entity = this.Ottieni(id);
			_ctx.Entry(entity).State = EntityState.Deleted;
		}

		public void Save() => _ctx.SaveChanges();


	}
}
