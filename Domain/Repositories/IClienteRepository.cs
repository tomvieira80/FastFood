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
        Task IncluiCliente(Cliente cliente);
        Task EditaCliente(Cliente cliente);
        Task RemoveCliente(Cliente cliente);

        Task<Cliente> RecuperaClientePorId(Guid id);
        Task<Cliente> RecuperaClientePorCPF(string cpf);

        Task<List<Cliente>> RecuperaClientes();
    }
}
