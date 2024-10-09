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

        public async Task IncluiClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            _postgresContext.Cliente.Add(cliente);
            await _postgresContext.SaveChangesAsync();
        }

    }
}
