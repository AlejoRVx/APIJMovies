using API.J.Movies.DAL.Models;
using API.J.Movies.Repository.IRepository;
using API.J.Movies.DAL;
using Microsoft.EntityFrameworkCore;

namespace API.J.Movies.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context; //Inyección de dependencias
        }
        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);  //Por lo menos uun registro que cumpla la condicion
            // SELECT CASE WHEN EXISTS (SELECT 1 FROM Categories WHERE Id = id) THEN 1 ELSE 0 END
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow; //horario universal

            await _context.Categories.AddAsync(category);

            return await SaveAsync();
            //SQL INSERT

        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryAsync(id); //primero consulto que sí exista la categoria

            if (category == null)
            {
                return false; //la categoria no existe
            }

            _context.Categories.Remove(category); //Elimino la categoria
            return await SaveAsync();
            //sql DELETE from Categories where Id = id
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name) //Ordena ascendentemente por Name
                .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id); // lambda expressions
            //Select * from Categories where Id = id 
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow; //horario universal

            _context.Categories.Update(category);

            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
