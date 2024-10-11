using Domain.Models;
using Domain.Repositories;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PostgresContext _postgresContext;

        public ClienteRepository(PostgresContext postgresContext) 
        { 
            _postgresContext = postgresContext ?? throw new ArgumentNullException(nameof(_postgresContext));
        }

        public async Task IncluiCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            _postgresContext.Cliente.Add(cliente);
            await _postgresContext.SaveChangesAsync();
        }


        public async Task EditaCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            _postgresContext.Cliente.Update(cliente);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task RemoveCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            _postgresContext.Cliente.Remove(cliente);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task<Cliente> RecuperaClientePorId(Guid id)
        {
            Cliente cliente =
                _postgresContext.Cliente.Where(c => c.Id.Equals(id)).FirstOrDefault();

            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            return cliente;
        }

        public async Task<Cliente> RecuperaClientePorCPF(string cpf)
        {
            Cliente cliente =
                 _postgresContext.Cliente.Where(c => c.CPF.Equals(cpf)).FirstOrDefault();

            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            return cliente;
        }

        public async Task<List<Cliente>> RecuperaClientes()
        {
            List<Cliente> clientes =
                 _postgresContext.Cliente.ToList();

            if (clientes == null)
                throw new ArgumentNullException(nameof(clientes));

            return clientes;
        }
    }
}
