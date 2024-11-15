using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Application.Validators;

namespace Unicam.Paradigmi.Web.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CategoryController : ControllerBase
	{
		public readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			this._categoryService = categoryService;
		}

		[HttpGet]
		[Route("create")]
		public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
		{
			var categoriaValidator = new CreateCategoryRequestValidator();
			categoriaValidator.Validate(request);
			var category = request.ToEntity();
			await _categoryService.AddCategoryAsync(category);

			var response = new CreateCategoryResponse
			{
				Category = new CategoryDTO(category)
			};
			return Ok(ResponseFactory.WithSuccess(response));
		}

		[HttpDelete]
		[Route("delete")]
		public async Task<IActionResult> DeleteCategory(DeleteCategoryRequest request)
		{
			var categoriaValidator = new DeleteCategoryRequestValidator();
			categoriaValidator.Validate(request);
			var category = request.ToEntity();
			await _categoryService.DeleteCategoryAsync(category);

			var response = new DeleteCategoryResponse
			{
				Category = new CategoryDTO()
			};
			return Ok(ResponseFactory.WithSuccess(response));
		}


	}
}
