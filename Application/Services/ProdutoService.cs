using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task IncluiProdutoAsync(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            await _produtoRepository.IncluiProdutoAsync(produto);  
        }

        public async Task EditaProdutoAsync(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            await _produtoRepository.EditaProdutoAsync(produto);
        }

        public async Task AtivarInativarProdutoAsync(Guid id, bool status)
        {

            await _produtoRepository.AtivarInativarProdutoAsync(id, status);
        }

        public async Task<Produto> RecuperaProdutoPorIdAsync(Guid id)
        {
            return await _produtoRepository.RecuperaProdutoPorIdAsync(id);
        }

        public async Task<List<Produto>> RecuperaProdutosAsync()
        {
            return await _produtoRepository.RecuperaProdutosAsync();

        }
    }
}
