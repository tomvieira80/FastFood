using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task IncluiPedidoAsync(Pedido pedido);
        Task AlterarStatusPedidoAsync(Guid id, Guid idStatusPedido);
        Task<Pedido> RecuperaPedidoPorIdAsync(Guid id);
        Task<Pedido> RecuperaPedidoPorNrPedidoAsync(int numeroPedido);
        Task<List<Pedido>> RecuperaPedidosAsync();
    }
}
