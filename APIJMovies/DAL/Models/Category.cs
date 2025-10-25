using System.ComponentModel.DataAnnotations;

namespace APIJMovies.DAL.Models
{
    public class Category: AuditBase
    {
        // Properties! se convierntes en columnas en la base de datos
        [Required] //este decorador indica que el campo es obligatorio
        public string Name { get; set; } // Nombre de la categoría
    }
}
