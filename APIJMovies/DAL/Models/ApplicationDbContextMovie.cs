using Microsoft.EntityFrameworkCore;
using APIJMovies.DAL.Models;

namespace APIJMovies.DAL.Models
{
    public class ApplicationDbContextMovie : DbContext
    {
        public ApplicationDbContextMovie(DbContextOptions<ApplicationDbContextMovie> options) : base(options)
        {
            
        }

        //Definir los DbSet (tablas) que voy a utilizar en mi aplicación
         public DbSet<Movie> Movies { get; set; }
    }
}
