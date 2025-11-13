using API.J.Movies.DAL.Dtos;
using API.J.Movies.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.J.Movies.Controllers
{
    [Route("api/[controller]")] // ruta url para navegar y hacer las consultas
    [ApiController] // indica que es un controlador de API
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        //Controlador no tiene codigo que representa logica de negocio, el controlador solo se encarga de orquestar la comunicación entre el frontend y el resto del backend

        [HttpGet] // indica que este metodo responde a solicitudes HTTP GET
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories); //http status code 200
        }
    }
}
