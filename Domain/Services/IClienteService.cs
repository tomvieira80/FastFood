using Domain.Models;

namespace Domain.Services
{
    public interface IClienteService
    {
        /// <summary>
        /// Inclui um novo Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        //// <exception cref="ValidationCoreException"></exception>
        Task IncluiClienteAsync(Cliente cliente);


        /// <summary>
        /// Edita um Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        //// <exception cref="ValidationCoreException"></exception>
        Task EditaClienteAsync(Cliente cliente);

        /// <summary>
        /// Remove um Cliente
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="status">bool</param>
        //// <exception cref="ValidationCoreException"></exception>
        Task AtivarInativarClienteAsync(Guid id, bool status);

        /// <summary>
        /// Recupera um Cliente pelo CPF
        /// </summary>
        /// <param name="CPF">Objeto Cliente</param>
        //// <exception cref="ValidationCoreException"></exception>
        Task<Cliente> RecuperaClientePorCPFAsync(string cpf);

        /// <summary>
        /// Recupera listagem de  Clientes        
        /// /// </summary>
        //// <exception cref="ValidationCoreException"></exception>
        Task<List<Cliente>> RecuperaListagemClienteAsync();
    }
}
