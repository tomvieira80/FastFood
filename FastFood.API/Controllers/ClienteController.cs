using Domain.Services;
using Domain.Models;
using FastFood.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace FastFood.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService) 
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> IncluiCliente(ClienteIncluir clienteIncluir)
        {
            var cliente = new Cliente
            {
                Nome = clienteIncluir.Nome,
                CPF = clienteIncluir.CPF,
                Email = clienteIncluir.Email,
                IdCliente = Guid.NewGuid()
            };

            await _clienteService.IncluiClienteAsync(cliente);

            return Ok(cliente);


        }

    }
}
