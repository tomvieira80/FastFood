namespace Domain.Services
{
    public interface IPedidoStatusService
    {
        Task<PedidoStatus> RecuperaPedidoStatusPorIdAsync(Guid id);
        Task<List<PedidoStatus>> RecuperaPedidoStatusAsync();
    }
}
