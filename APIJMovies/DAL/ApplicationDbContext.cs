using APIJMovies.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIJMovies.DAL
{
    public class ApplicationDbContext: DbContext
    {
        //Constructor para poder inicializar la clase base DbContext en otras palabras, virtualizar mi BD
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //Definir los DbSet (tablas) que voy a utilizar en mi aplicación
        public DbSet<Category> Categories { get; set; }
        }
}
