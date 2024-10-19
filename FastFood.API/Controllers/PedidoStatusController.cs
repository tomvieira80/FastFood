using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PedidoStatusController : Controller
    {
        private readonly IPedidoStatusService _statusService;
        public PedidoStatusController(IPedidoStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> RecuperarPorId(Guid id)
        {
            var status = await _statusService.RecuperaPedidoStatusPorIdAsync(id);

            if (status == null) {
                return NotFound("Status não localizado");            }

            return Ok(status);
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarListagem()
        {
            return Ok(await _statusService.RecuperaPedidoStatusAsync());
        }
    }
}
