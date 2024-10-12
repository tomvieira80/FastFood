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
        Task IncluiCliente(Cliente cliente);


        /// <summary>
        /// Edita um Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        //// <exception cref="ValidationCoreException"></exception>
        Task EditaCliente(Cliente cliente);

        /// <summary>
        /// Remove um Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        //// <exception cref="ValidationCoreException"></exception>
        Task RemoveCliente(Guid id);

        /// <summary>
        /// Recupera um Cliente pelo CPF
        /// </summary>
        /// <param name="CPF">Objeto Cliente</param>
        //// <exception cref="ValidationCoreException"></exception>
        Task<Cliente> RecuperaClientePorCPF(string cpf);

        /// <summary>
        /// Recupera listagem de  Clientes        
        /// /// </summary>
        //// <exception cref="ValidationCoreException"></exception>
        Task<List<Cliente>> RecuperaListagemCliente();
    }
}
