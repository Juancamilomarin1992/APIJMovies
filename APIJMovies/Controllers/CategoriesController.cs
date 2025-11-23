using APIJMovies.DAL.Dtos;
using APIJMovies.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIJMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<CategoryDto>>> getCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories); // 200 OK with the list of categories
        }

        [HttpGet ("{id:int}", Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CategoryDto>> GetCategoryAsync(int id)
        {
            var categoryDto = await _categoryService.GetCategoryAsync(id);
            return Ok(categoryDto); // 200 OK with the list of categories
        }

    }
}
