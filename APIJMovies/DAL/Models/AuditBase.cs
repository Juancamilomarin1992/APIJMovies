using System.Data;
using System.ComponentModel.DataAnnotations; // <-- Add this using directive

namespace APIJMovies.DAL.Models
{
    public class AuditBase
    {
        //Decoradores de Data Annotations
        [Key] //PK
        public virtual int Id { get; set; } // Primary Key de todas las tabla
        public virtual DateTime CreatedDate { get; set; } //guardar la fecha de creación de un registro en BD
        public virtual DateTime ModifiedDate { get; set; } //guardar la fecha de modificación de un registro en BD   
    }
}
