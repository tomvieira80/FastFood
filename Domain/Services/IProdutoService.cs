namespace Domain.Services
{
    public interface IProdutoService
    {
        Task IncluiProdutoAsync(Produto Produto);
        Task EditaProdutoAsync(Produto Produto);
        Task AtivarInativarProdutoAsync(Guid id, bool status);
        Task<Produto> RecuperaProdutoPorIdAsync(Guid id);
        Task<List<Produto>> RecuperaProdutosAsync();
    }
}
