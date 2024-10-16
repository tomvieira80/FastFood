using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly PostgresContext _postgresContext;

        public CategoriaRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public async Task<Categoria> RecuperaCategoriaPorIdAsync(Guid id)
        {
            Categoria categoria = await _postgresContext.Categoria.Where(c => c.IdCategoria.Equals(id)).FirstOrDefaultAsync();            

            return categoria;
        }

        public async Task<List<Categoria>> RecuperaCategoriasAsync()
        {
            List<Categoria> categoria = await _postgresContext.Categoria.ToListAsync();

            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            return categoria;
        }
    }
}
