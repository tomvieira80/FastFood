using Domain.Models;

namespace Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task IncluiProdutoAsync(Produto Produto);
        Task EditaProdutoAsync(Produto Produto);
        Task AtivarInativarProdutoAsync(Guid id, bool status);
        Task<Produto> RecuperaProdutoPorIdAsync(Guid id);        
        Task<List<Produto>> RecuperaProdutosAsync();
    }
}
