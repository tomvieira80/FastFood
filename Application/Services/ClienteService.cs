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

        public ClienteService(IClienteRepository clienteRepository) 
        { 
            _clienteRepository = clienteRepository; 
        }

       

        public async Task IncluiClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            await _clienteRepository.IncluiClienteAsync(cliente);
        }

        public async Task EditaClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            await _clienteRepository.EditaClienteAsync(cliente);
        }

        public async Task AtivarInativarClienteAsync(Guid id, bool status)
        {
            
            await _clienteRepository.AtivarInativarClienteAsync(id, status);
        }

        public async Task<Cliente> RecuperaClientePorCPFAsync(string cpf)
        {
            return await _clienteRepository.RecuperaClientePorCPFAsync(cpf);
        }

        public async Task<List<Cliente>> RecuperaListagemClienteAsync()
        {
            return await _clienteRepository.RecuperaClientesAsync();

        }
    }
}
