using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PostgresContext _postgresContext;

        public ProdutoRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public async Task IncluiProdutoAsync(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            _postgresContext.Produto.Add(produto);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task EditaProdutoAsync(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            _postgresContext.Produto.Update(produto);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task AtivarInativarProdutoAsync(Guid id, bool status)
        {
            var produto = _postgresContext.Produto.Where(c => c.IdProduto.Equals(id)).FirstOrDefault();

            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            produto.Ativo = status;
            produto.DataAlteracao = DateTime.Now;

            _postgresContext.Produto.Update(produto);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task<Produto> RecuperaProdutoPorIdAsync(Guid id)
        {
            var produto = await _postgresContext.Produto.Where(c => c.IdProduto.Equals(id)).FirstOrDefaultAsync();           

            return produto;
        }

        public async Task<List<Produto>> RecuperaProdutosAsync()
        {
            var produto = await _postgresContext.Produto.ToListAsync();                      

            return produto;
        }
    }
}
