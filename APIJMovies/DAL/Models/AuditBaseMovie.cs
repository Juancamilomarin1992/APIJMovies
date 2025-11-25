using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIJMovies.DAL.Models
{
    public class AuditBaseMovie
    {
        private DbContextOptions<ApplicationDbContextMovie> options;

        public AuditBaseMovie(DbContextOptions<ApplicationDbContextMovie> options)
        {
            this.options = options;
        }

        [Key] // Indica que esta propiedad es la clave primaria
        public virtual int Id { get; set; } // Primary Key de todas las tabla
        public virtual DateTime CreatedDate { get; set; } //guardar la fecha de creación de un registro en BD
        public virtual DateTime UpdatedDate { get; set; } //guardar la fecha de modificación de un registro en BD
        public virtual string Name { get; set; } //guardar el nombre de la pelicula
        public virtual int Duration { get; set; } //guardar la duracion de la pelicula en minutos
        public virtual string Description { get; set; }
        public virtual string Clasification { get; set; }

    }
}
