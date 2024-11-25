using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pedido_plus_backend.Dtos.Category;
using pedido_plus_backend.Models;
using pedido_plus_backend.Services.Interfaces;

namespace pedido_plus_backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetCategory")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory(int? id)
        {
            if (id.HasValue)
            {
                var category = await _categoryService.GetCategoryById(id.Value);
                if (category == null)
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(category);
            }
            else
            {
                var categories = await _categoryService.GetCategories();
                if (categories == null || categories.Count == 0)
                {
                    return NotFound("Categorias não encontrada.");
                }
                return Ok(categories);
            }
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();

            await _categoryService.CreateCategory(categoryDto);

            return new CreatedAtRouteResult("GetCategory", categoryDto);
        }

        [HttpPut("UpdateCategory/{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CreateCategoryDto categoryDto)
        {
            categoryDto.Id = id;

            if (categoryDto == null)
                return BadRequest();

            await _categoryService.UpdateCategory(categoryDto);

            return Ok(categoryDto);
        }
    }
}