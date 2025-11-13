using API.J.Movies.DAL.Dtos;
using API.J.Movies.DAL.Models;

namespace API.J.Movies.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync(); 

        Task<CategoryDto> GetCategoryAsync(int id); 

        Task<bool> CategoryExistsByIdAsync(int id); 

        Task<bool> CategoryExistsByNameAsync(string name); 

        Task<bool> CreateCategoryAsync(Category category); 

        Task<bool> UpdateCategoryAsync(Category category); 

        Task<bool> DeleteCategoryAsync(int id); 
    }
}
