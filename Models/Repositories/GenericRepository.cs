﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


		public T Ottieni(T id) => id != null ? _ctx.Set<T>().Find(id) : throw new NullReferenceException("Id sconosciuto");

		public void Elimina(T id)
		{
			var entity = Ottieni(id);
			_ctx.Entry(entity).State = EntityState.Deleted;
		}

		public void Save() => _ctx.SaveChanges();


	}
}