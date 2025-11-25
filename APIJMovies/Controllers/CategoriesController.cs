using APIJMovies.DAL.Dtos;
using APIJMovies.Services.IServices;
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

        [HttpGet(Name = "GetCategoriesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<CategoryDto>>> getCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories); // 200 OK with the list of categories
        }

        [HttpGet("{id}", Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       

        public async Task<ActionResult<CategoryDto>> GetCategoryAsync(int id)
        {
            try 
            {
                var categoryDto = await _categoryService.GetCategoryAsync(id);
                return Ok(categoryDto); // 200 OK with the list of categories
            } 
            catch (InvalidOperationException ex)when (ex.Message.Contains("no se encontro"))
            {
                return NotFound(new { ex.Message });
            }         
        }
        [HttpPost(Name = "CreateCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult<CategoryDto>> CreateCategoryAsync([FromBody] CategoryCreateUdateDto categoryCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdCategory = await _categoryService.CreateCategoryAsync(categoryCreateDto);

                return CreatedAtRoute
                    ("GetCategoryAsync",
                    new { id = createdCategory.Id },
                    createdCategory
                    );
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ya exite"))
            {
                return Conflict(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CategoryDto>> UpdateCategoryAsync([FromBody] CategoryCreateUdateDto dto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatetedCategory = await _categoryService.UdateCategoryAsync(dto, id);
                return Ok(updatetedCategory);

            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ya exite"))
            {
                return Conflict(new { ex.Message });
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("no se encontro"))
            {
                return NotFound(new { ex.Message });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                var deletetedCategory = await _categoryService.DeleteCategoryAsync( id);
                return Ok(deletetedCategory);//Retorno 200 OK si se elimino correctamente

            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("no se encontro"))
            {
                return NotFound(new { ex.Message });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
