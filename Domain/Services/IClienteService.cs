using Domain.Models;

namespace Domain.Services
{
    public interface IClienteService
    {        
        Task IncluiClienteAsync(Cliente cliente);
                        
        Task EditaClienteAsync(Cliente cliente);
               
        Task AtivarInativarClienteAsync(Guid id, bool status);
                
        Task<Cliente> RecuperaClientePorCPFAsync(string cpf);
               
        Task<List<Cliente>> RecuperaListagemClienteAsync();
        Task<Cliente> RecuperaClientePorIdAsync(Guid id);
    }
}
