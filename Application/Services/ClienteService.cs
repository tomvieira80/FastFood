using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmailService _emailAdapter;

        public ClienteService(IClienteRepository clienteRepository, IEmailService emailAdapter)
        {
            _clienteRepository = clienteRepository;
            _emailAdapter = emailAdapter;
        }


        public async Task IncluiClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            await _clienteRepository.IncluiClienteAsync(cliente);
            _emailAdapter.SendEmail("fastfood@gmail.com", cliente.Email, "Cliente cadastrado com sucesso", "Seu Cadastro foi realizado com sucesso.");
          
        }

        public async Task EditaClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            await _clienteRepository.EditaClienteAsync(cliente);
            _emailAdapter.SendEmail("fastfood@gmail.com", cliente.Email, "Cliente alterado com sucesso", "Seu Cadastro foi alterado com sucesso.");
        }

        public async Task AtivarInativarClienteAsync(Guid id, bool status)
        {
            
            await _clienteRepository.AtivarInativarClienteAsync(id, status);
        }

        public async Task<Cliente> RecuperaClientePorCPFAsync(string cpf)
        {
            return await _clienteRepository.RecuperaClientePorCPFAsync(cpf);
        }

        public async Task<Cliente> RecuperaClientePorIdAsync(Guid id)
        {
            return await _clienteRepository.RecuperaClientePorIdAsync(id);
        }

        public async Task<List<Cliente>> RecuperaListagemClienteAsync()
        {
            return await _clienteRepository.RecuperaClientesAsync();

        }
    }
}
