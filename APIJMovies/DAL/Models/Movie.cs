using System.ComponentModel.DataAnnotations;

namespace APIJMovies.DAL.Models
{
    public class Movie: AuditBaseMovie
    {
        [Required] //el campo Name es obligatorio
        [Display(Name = "Nombre de la pelicula")]//personalizar el nombre de la propiedad
        public string Name { get; set; }
    }
}
