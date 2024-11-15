﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface ILibroService
	{
		Categoria OttieniCategoria(Libro IdLibro,string categoria);

		List<Categoria> OttieniCategorie(Libro IdLibro);

		Task UploadLibroAsync(Libro libro);
	}
}
