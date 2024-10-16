using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository) 
        { 
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> RecuperaCategoriaPorIdAsync(Guid id)
        {
            return await _categoriaRepository.RecuperaCategoriaPorIdAsync(id);
        }

        public async Task<List<Categoria>> RecuperaCategoriasAsync()
        {
            return await _categoriaRepository.RecuperaCategoriasAsync();

        }
    }
}
