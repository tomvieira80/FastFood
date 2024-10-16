using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PostgresContext _postgresContext;

        public ClienteRepository(PostgresContext postgresContext) 
        { 
            _postgresContext = postgresContext ?? throw new ArgumentNullException(nameof(_postgresContext));
        }

        public async Task IncluiClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            

            _postgresContext.Cliente.Add(cliente);
            await _postgresContext.SaveChangesAsync();
        }


        public async Task EditaClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            _postgresContext.Cliente.Update(cliente);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task AtivarInativarClienteAsync(Guid id, bool status) 
        {
            var cliente = _postgresContext.Cliente.Where(c => c.IdCliente.Equals(id)).FirstOrDefault();

            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            cliente.Ativo = status;
            cliente.DataAlteracao = DateTime.Now;

            _postgresContext.Cliente.Update(cliente);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task<Cliente> RecuperaClientePorIdAsync(Guid id)
        {
            Cliente cliente = await _postgresContext.Cliente.Where(c => c.IdCliente.Equals(id)).FirstOrDefaultAsync();

            //if (cliente == null)
            //    throw new ArgumentNullException(nameof(cliente));

            return cliente;
        }

        public async Task<Cliente> RecuperaClientePorCPFAsync(string cpf)
        {
            var cliente = await _postgresContext.Cliente.Where(c => c.CPF.Equals(cpf)).FirstOrDefaultAsync();

            //if (cliente == null)
            //    throw new ArgumentNullException(nameof(cliente));

            return cliente;
        }

        public async Task<List<Cliente>> RecuperaClientesAsync()
        {
            List<Cliente> clientes = await _postgresContext.Cliente.ToListAsync();

            return clientes;
        }

        public bool CPFJaCadastrado(string cpf)
        {
            return _postgresContext.Cliente.Where(c => c.CPF.Equals(cpf)).Any();
        }
    }
}
