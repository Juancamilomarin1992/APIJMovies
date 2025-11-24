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

        public  Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUdateDto categoryCreateDto) 
        {
            // validar si la categoria ya existe
            var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name);

            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de {categoryCreateDto.Name}");  
            }
            // mapear el Dto de la entidad
            var category = _mapper.Map<Category>(categoryCreateDto);
            // crear la categoria en el repositorio
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("ocurrio un error al crear la categoria");
            }
            //Mapear la entidad creada a Dto
            return _mapper.Map<CategoryDto>(category);  
        }
        public Task<bool> CreateCategoryAsync(Category category)
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

        public async Task<CategoryDto> UdateCategoryAsync(CategoryCreateUdateDto dto, int id)
        {
            // validar si la categoria ya existe
            var categoryExists = await _categoryRepository.GetCategoryAsync(id);

            if (categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontro la categoría con Id: {id}");
            }

            var nameExists = await _categoryRepository.CategoryExistsByNameAsync(dto.Name);
            if (nameExists )
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de {dto.Name}");
            }

            // mapear el Dto de la entidad
            _mapper.Map(dto, categoryExists);

            // actualizar la categoria en el repositorio
            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(categoryExists);
            if (!categoryUpdated)
            {
                throw new Exception("ocurrio un error al actualizar la categoria");
            }
            //Retornar el Dto actualizado
            return _mapper.Map<CategoryDto>(categoryExists);
        }
        /*public Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }*/
    }
}






