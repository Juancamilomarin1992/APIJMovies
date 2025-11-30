using System.ComponentModel.DataAnnotations;

namespace APIJMovies.DAL.Dtos
{
    public class MovieCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la pelicula es obligatorio")]
        [MaxLength(100, ErrorMessage = "El número maximo de caracteres es de 200.")]
        public string Name { get; set; }
        public string Clasification { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
    }
}
