using Domain.Models;
using Domain.Services;
using Domain.Validators;
using FastFood.API.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace FastFood.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteValidator _clienteValidator;

        public ClienteController(IClienteService clienteService, IClienteValidator validator) 
        {
            _clienteService = clienteService;
            _clienteValidator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(ClienteInsert clienteInsert)
        {   
            var cliente = new Cliente
            {
                IdCliente = Guid.NewGuid(),
                Nome = clienteInsert.Nome,
                CPF = clienteInsert.CPF,
                Email = clienteInsert.Email,
                DataAlteracao = DateTime.Now,
                Ativo = true
            };

            if (!_clienteValidator.Validate(cliente, true, out var errors))
            {
                return BadRequest(new { Errors = errors });
            }

            await _clienteService.IncluiClienteAsync(cliente);

            return Ok(cliente);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Alterar(Guid id,ClienteUpdate clienteUpdate)
        {
            var cliente = new Cliente
            {
                IdCliente = id, 
                Nome = clienteUpdate.Nome,
                CPF = clienteUpdate.CPF,
                Email = clienteUpdate.Email,
                DataAlteracao = DateTime.Now,
                Ativo = clienteUpdate.Ativo
            };

            if (!_clienteValidator.Validate(cliente, false, out var errors))
            {
                return BadRequest(new { Errors = errors });
            }

            await _clienteService.EditaClienteAsync(cliente);

            return Ok(cliente);
        }

        [HttpPatch("{id:Guid}/{status:bool}")]
        public async Task<IActionResult> AtivarInativar(Guid id, bool status)
        {
            await _clienteService.AtivarInativarClienteAsync(id, status);

            return Ok(new {mensagem = "Operação realizada com sucesso."});
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> RecuperarPorCPF(string cpf)
        {
            var cliente = await _clienteService.RecuperaClientePorCPFAsync(cpf);

            if (cliente == null) {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarListagem()
        {
            return Ok(await _clienteService.RecuperaListagemClienteAsync());
        }
    }
}