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

       

        public async Task IncluiCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            await _clienteRepository.IncluiCliente(cliente);
        }

        public async Task EditaCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            await _clienteRepository.EditaCliente(cliente);
        }

        public async Task RemoveCliente(Guid id)
        {
            Cliente cliente = await _clienteRepository.RecuperaClientePorId(id);
           
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            await _clienteRepository.RemoveCliente(cliente);
        }

        public async Task<Cliente> RecuperaClientePorCPF(string cpf)
        {
            return await _clienteRepository.RecuperaClientePorCPF(cpf);
        }

        public async Task<List<Cliente>> RecuperaListagemCliente()
        {
            return await _clienteRepository.RecuperaClientes();

        }
    }
}
