using Microsoft.AspNetCore.Authorization;
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
	[Authorize]
	[Route("api/v1/[controller]")]
	public class CategoryController : ControllerBase
	{
		public readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			this._categoryService = categoryService;
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
		{
			var createCategoryValidator = new CreateCategoryRequestValidator();
			createCategoryValidator.Validate(request);

			var category = request.ToEntity();

			var createCategory = await _categoryService.CreateCategoryAsync(category);

			var response = new CreateCategoryResponse
			{
				CategoryDTO = new CategoryDTO
				{
					IdCategory = category.IdCategory,
					CategoryName = category.CategoryName,
				}
			};

			return Ok(ResponseFactory.WithSuccess(response));
		}

		[HttpDelete]
		[Route("delete")]
		public async Task<IActionResult> DeleteCategoryAsync(DeleteCategoryRequest request)
		{
			var categoriaValidator = new DeleteCategoryRequestValidator();
			categoriaValidator.Validate(request);

			var result = await _categoryService.DeleteCategoryAsync(request.IdCategory);

			var deleteCategoryResponse = new DeleteCategoryResponse
			{
				Result = result
			};
			return Ok(ResponseFactory.WithSuccess(deleteCategoryResponse));
		}


	}
}
