using Domain.Models;

namespace Domain.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> RecuperaCategoriaPorIdAsync(Guid id);
        Task<List<Categoria>> RecuperaCategoriasAsync();
    }
}
