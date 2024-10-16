using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICategoriaService
    {
        Task<Categoria> RecuperaCategoriaPorIdAsync(Guid id);
        Task<List<Categoria>> RecuperaCategoriasAsync();
    }
}
