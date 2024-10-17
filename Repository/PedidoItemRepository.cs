using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private readonly PostgresContext _postgresContext;

        public PedidoItemRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public async Task IncluiPedidoItemAsync(PedidoItem pedidoItem)
        {
            if (pedidoItem == null)
                throw new ArgumentNullException(nameof(pedidoItem));

            _postgresContext.PedidoItem.Add(pedidoItem);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task EditaPedidoItemAsync(PedidoItem pedidoItem)
        {
            if (pedidoItem == null)
                throw new ArgumentNullException(nameof(pedidoItem));

            _postgresContext.PedidoItem.Add(pedidoItem);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task AtivarInativarPedidoItemAsync(Guid id, bool status)
        {
            var pedidoItem = _postgresContext.PedidoItem.Where(p => p.IdPedidoItem.Equals(id)).FirstOrDefault();

            if (pedidoItem == null)
                throw new ArgumentNullException(nameof(pedidoItem));

            pedidoItem.Ativo = status;
            pedidoItem.DataAlteracao = DateTime.Now;

            _postgresContext.PedidoItem.Update(pedidoItem);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task<PedidoItem> RecuperaPedidoItemPorIdAsync(Guid id)
        {
            var pedidoItem = await _postgresContext.PedidoItem.Where(c => c.IdPedidoItem.Equals(id)).FirstOrDefaultAsync();

            return pedidoItem;
        }
        public async Task<List<PedidoItem>> RecuperaPedidoItemAtivoPorIdPedidoAsync(Guid id)
        {
            var pedidoItem = await _postgresContext.PedidoItem.Where(p => p.IdPedido.Equals(id) && p.Ativo == true).ToListAsync();

            return pedidoItem;
        }
        public async Task<List<PedidoItem>> RecuperaPedidoItensAsync()
        {
            var pedidoItem = await _postgresContext.PedidoItem.ToListAsync();

            return pedidoItem;
        }
    }
}
