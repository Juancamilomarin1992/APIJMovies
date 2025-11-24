using APIJMovies.DAL.Dtos;
using APIJMovies.DAL.Models;

namespace APIJMovies.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync(); 
        Task<CategoryDto> GetCategoryAsync(int id); 
        Task<bool> CategoryExistsByIdAsync(int id); 
        Task<bool> CategoryExistsByNameAsync(string name); 
        Task<bool> CreateCategoryAsync(Category category); 
        Task<bool> UpdateCategoryAsync(Category category); 
        Task<bool> DeleteCategoryAsync(int id); 
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
    }
}
