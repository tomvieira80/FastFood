using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
