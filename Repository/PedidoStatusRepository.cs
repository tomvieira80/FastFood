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
    public class PedidoStatusRepository : IPedidoStatusRepository
    {
        private readonly PostgresContext _postgresContext;

        public PedidoStatusRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public async Task<PedidoStatus> RecuperaPedidoStatusPorIdAsync(Guid id)
        {
            var pedidoStatus = await _postgresContext.PedidoStatus.Where(c => c.IdPedidoStatus.Equals(id)).FirstOrDefaultAsync();                    

            return pedidoStatus;
        }

        public async Task<List<PedidoStatus>> RecuperaPedidoStatusAsync()
        {
            var pedidoStatus = await _postgresContext.PedidoStatus.ToListAsync();

            if (pedidoStatus == null)
                throw new ArgumentNullException(nameof(pedidoStatus));

            return pedidoStatus;
        }
    }
}
