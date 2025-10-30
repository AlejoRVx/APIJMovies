using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        //propiedades!! se convierten en columnas en la base de datos
        //comando prop para generar una propiedad
        [Required] //este decorador indica que el campo es obligatorio (no acepta nulls)
        public string Name { get; set; }
    }
}
