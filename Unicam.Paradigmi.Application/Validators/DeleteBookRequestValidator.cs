﻿using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Validators
{
	public class DeleteBookRequestValidator : AbstractValidator<DeleteBookRequest>
	{

		public DeleteBookRequestValidator()
		{
			RuleFor(n => n.Nome)
				.NotEmpty()
				.WithMessage("Il campo Nome non può essere vuoto")
				.NotNull()
				.WithMessage("Il campo Nome non può essere nullo");

		}
	}
}