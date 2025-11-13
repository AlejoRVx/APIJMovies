using API.J.Movies.DAL.Models;

namespace API.J.Movies.Repository.IRepository
{
    public interface ICategoryRepository
    { 
        Task<ICollection<Category>> GetCategoriesAsync(); // Me retorna UNA LISTA DE CATEGORIAS
        //Task de los metodos asincronos, es la programación que permite trabajar multi hilos (multi tareas) simultaneamente
        //Get generico no tiene parametros

        Task<Category> GetCategoryAsync(int id); // Me retorna UNA CATEGORIA por su ID

        Task<bool> CategoryExistsByIdAsync(int id); // Me retorna TRUE o FALSE si la categoria existe por su ID

        Task<bool> CategoryExistsByNameAsync(string name); // Me retorna TRUE o FALSE si la categoria existe por su NOMBRE

        Task<bool> CreateCategoryAsync(Category category); // Me crea UNA CATEGORIA

        Task<bool> UpdateCategoryAsync(Category category); // Me actualiza UNA CATEGORIA -- puedo actualizar el nombre y la fecha de actualización

        Task<bool> DeleteCategoryAsync(int id); // Me elimina UNA CATEGORIA

    }
}
