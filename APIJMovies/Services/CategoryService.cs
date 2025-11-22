using APIJMovies.DAL;
using APIJMovies.DAL.Models;
using APIJMovies.Services.IServices;
using APIJMovies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIJMovies.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
           _categoryRepository = categoryRepository;
        }

        public Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
