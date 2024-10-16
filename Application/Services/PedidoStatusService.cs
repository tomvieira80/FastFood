using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PedidoStatusService : IPedidoStatusService
    {
        private readonly IPedidoStatusRepository _pedidoStatusRepository;

        public PedidoStatusService(IPedidoStatusRepository pedidoStatusRepository)
        {
            _pedidoStatusRepository = pedidoStatusRepository;
        }

        public async Task<PedidoStatus> RecuperaPedidoStatusPorIdAsync(Guid id)
        {
            return await _pedidoStatusRepository.RecuperaPedidoStatusPorIdAsync(id);
        }

        public async Task<List<PedidoStatus>> RecuperaPedidoStatusAsync()
        {
            return await _pedidoStatusRepository.RecuperaPedidoStatusAsync();

        }
    }
}
