using System.ComponentModel.DataAnnotations;

namespace APIJMovies.DAL.Dtos
{
    public class CategoryDto
    {
        [Required(ErrorMessage ="El nombre de la categoria es obligatorio")]
        [MaxLength(100, ErrorMessage ="El número maximo de caracteres es de 100.")]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
