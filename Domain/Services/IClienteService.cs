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
    }
}
