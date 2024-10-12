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
        public async Task<IActionResult> Inclui(Dtos.ClienteInsert clienteInsert)
        {
            var cliente = new Domain.Models.Cliente
            {
                Id = Guid.NewGuid(),
                Nome = clienteInsert.Nome,
                CPF = clienteInsert.CPF,
                Email = clienteInsert.Email,
                DataCadastro = DateTime.Now
            };

            await _clienteService.IncluiCliente(cliente);

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Altera(Dtos.ClienteUpdate clienteUpdate)
        {
            var cliente = new Domain.Models.Cliente
            {
                Id = clienteUpdate.Id, 
                Nome = clienteUpdate.Nome,
                CPF = clienteUpdate.CPF,
                Email = clienteUpdate.Email,
                DataCadastro = DateTime.Now
            };

            await _clienteService.IncluiCliente(cliente);

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _clienteService.RemoveCliente(id);

            return Ok(null);
        }

        [HttpGet]
        public async Task<IActionResult> RecuperaPorCPF(string cpf)
        {
            return Ok(await _clienteService.RecuperaClientePorCPF(cpf));
        }

        [HttpGet]
        public async Task<IActionResult> RecuperaListagem()
        {
            return Ok(await _clienteService.RecuperaListagemCliente());
        }
    }
}