using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPedidoItemRepository
    {
        Task IncluiPedidoItemAsync(PedidoItem pedidoItem);
        Task EditaPedidoItemAsync(PedidoItem pedidoItem);
        Task AtivarInativarPedidoItemAsync(Guid id, bool status);
        Task<PedidoItem> RecuperaPedidoItemPorIdAsync(Guid id);
        Task<List<PedidoItem>> RecuperaPedidoItemAtivoPorIdPedidoAsync(Guid id);
        Task<List<PedidoItem>> RecuperaPedidoItensAsync();


    }
}
