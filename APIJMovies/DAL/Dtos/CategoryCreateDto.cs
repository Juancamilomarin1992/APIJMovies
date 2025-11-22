using System.ComponentModel.DataAnnotations;

namespace APIJMovies.DAL.Dtos
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio")]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]

        public string Name { get; set; }
    }
}
