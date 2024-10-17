using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PostgresContext _postgresContext;

        public PedidoRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public async Task IncluiPedidoAsync(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido));

            _postgresContext.Pedido.Add(pedido);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task AlterarStatusPedidoAsync(Guid id, Guid idStatusPedido)
        {
            var pedido = _postgresContext.Pedido.Where(p => p.IdPedido.Equals(id)).FirstOrDefault();

            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido));

            pedido.IdPedidoStatus = idStatusPedido;
            pedido.DataAlteracao = DateTime.Now;

            _postgresContext.Pedido.Update(pedido);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task<Pedido> RecuperaPedidoPorIdAsync(Guid id)
        {
            var pedido = await _postgresContext.Pedido.Where(c => c.IdPedido.Equals(id)).FirstOrDefaultAsync();

            return pedido;
        }

        public async Task<Pedido> RecuperaPedidoPorNrPedidoAsync(int numeroPedido)
        {
            var pedido = await _postgresContext.Pedido.Where(c => c.NumeroPedido.Equals(numeroPedido)).FirstOrDefaultAsync();

            return pedido;
        }

        public async Task<List<Pedido>> RecuperaPedidosAsync()
        {
            var pedido = await _postgresContext.Pedido.ToListAsync();

            return pedido;
        }


    }
}
