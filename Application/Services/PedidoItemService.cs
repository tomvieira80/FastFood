using Domain.Repositories;
using Domain.Services;
using System.Data.SqlTypes;

namespace Application.Services
{
    public class PedidoItemService : IPedidoItemService
    {
        public readonly IPedidoItemRepository _pedidoItemRepository;

        public PedidoItemService(IPedidoItemRepository pedidoItemRepository)
        {
            _pedidoItemRepository = pedidoItemRepository;
        }

        public async Task IncluiPedidoItemAsync(PedidoItem pedidoItem)
        {
            if (pedidoItem == null)
                throw new ArgumentNullException(nameof(pedidoItem));

            await _pedidoItemRepository.IncluiPedidoItemAsync(pedidoItem);
        }

        public async Task EditaPedidoItemAsync(PedidoItem pedidoItem)
        {
            if (pedidoItem == null)
                throw new ArgumentNullException(nameof(pedidoItem));

            await _pedidoItemRepository.EditaPedidoItemAsync(pedidoItem);
        }

        public async Task AtivarInativarPedidoItemAsync(Guid id, bool status)
        {

            await _pedidoItemRepository.AtivarInativarPedidoItemAsync(id, status);
        }

        public async Task<PedidoItem> RecuperaPedidoItemPorIdAsync(Guid id)
        {
            return await _pedidoItemRepository.RecuperaPedidoItemPorIdAsync(id);
        }

        public async Task<List<PedidoItem>> RecuperaPedidoItemAtivoPorIdPedidoAsync(Guid idPedido)
        {
            return await _pedidoItemRepository.RecuperaPedidoItemAtivoPorIdPedidoAsync(idPedido);
        }

        public async Task<List<PedidoItem>> RecuperaPedidoItensAsync()
        {
            return await _pedidoItemRepository.RecuperaPedidoItensAsync();
        }
    }
}
