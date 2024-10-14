using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClienteRepository
    {
        Task IncluiClienteAsync(Cliente cliente);
        Task EditaClienteAsync(Cliente cliente);
        Task AtivarInativarClienteAsync(Guid id, bool status);
        Task<Cliente> RecuperaClientePorIdAsync(Guid id);
        Task<Cliente> RecuperaClientePorCPFAsync(string cpf);

        Task<List<Cliente>> RecuperaClientesAsync();
    }
}
