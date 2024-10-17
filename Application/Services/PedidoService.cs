using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task IncluiPedidoAsync(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido));

            await _pedidoRepository.IncluiPedidoAsync(pedido);
        }

        public async Task AlterarStatusPedidoAsync(Guid id, Guid idStatusPedido)
        {     
            await _pedidoRepository.AlterarStatusPedidoAsync(id, idStatusPedido);
        }

        public async Task<Pedido> RecuperaPedidoPorIdAsync(Guid id)
        {
            return await _pedidoRepository.RecuperaPedidoPorIdAsync(id);
        }

        public async Task<Pedido> RecuperaPedidoPorNrPedidoAsync(int numeroPedido)
        {
            return await _pedidoRepository.RecuperaPedidoPorNrPedidoAsync(numeroPedido);
        }

        public async Task<List<Pedido>> RecuperaPedidosAsync()
        {
            return await _pedidoRepository.RecuperaPedidosAsync();
        }


    }
}
