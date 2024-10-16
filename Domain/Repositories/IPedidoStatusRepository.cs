namespace Domain.Repositories
{
    public interface IPedidoStatusRepository
    {
        Task<PedidoStatus> RecuperaPedidoStatusPorIdAsync(Guid id);
        Task<List<PedidoStatus>> RecuperaPedidoStatusAsync();
    }
}
