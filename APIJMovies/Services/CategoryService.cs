using APIJMovies.DAL;
using APIJMovies.DAL.Models;
using APIJMovies.Services.IServices;
using APIJMovies.Repository.IRepository;
using AutoMapper;
using APIJMovies.DAL.Dtos;

namespace APIJMovies.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
           _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); //solo estoy llamando al metodo desde la capa de repositorio
            return _mapper.Map<ICollection<CategoryDto>>(categories); //mapeo la lista de categorias a CategoryDto
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id); 
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
