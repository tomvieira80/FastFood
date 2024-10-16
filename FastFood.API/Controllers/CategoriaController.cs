using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Services;
using Application.Services;

namespace FastFood.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> RecuperarPorId(Guid id)
        {

            var categoria = await _categoriaService.RecuperaCategoriaPorIdAsync(id);

            if (categoria == null) 
            {
                return NotFound("Categoria não localizada");
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarListagem()
        {
            return Ok(await _categoriaService.RecuperaCategoriasAsync());
        }
    }
}
