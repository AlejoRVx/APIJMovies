using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models
{
    public class AuditBase
    {
        //Decorator a Data Annotations
        [Key] //PK Este data annotation indica que el campo es la clave primaria
        public virtual int Id { get; set; } //PK de todas las tablas

        public virtual DateTime CreatedDate { get; set; } //este me sirve para guardar la fecha de creación de un registro de base de datos

        public virtual DateTime ModifiedDate { get; set; } //para guardar la fecha de modificación de un registro de base de datos
    }
}
