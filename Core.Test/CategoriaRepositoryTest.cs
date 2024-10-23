using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Repositories;
using Moq;
using Xunit;

namespace Core.Test
{
    public class CategoriaRepositoryTest
    {
        private readonly Mock<ICategoriaRepository> _mockRepo;
        private readonly Categoria _categoria;

        public CategoriaRepositoryTest()
        {
            _mockRepo = new Mock<ICategoriaRepository>();

            _categoria = new Categoria
            {
                IdCategoria = Guid.NewGuid(),
                NomeCategoria = "Bebidas",
                DataAlteracao = DateTime.Now,
                Ativo = true,
                Produtos = new List<Produto>()
            };
        }

        [Fact]
        public async Task RecuperaCategoriaPorIdAsync_Deve_Retornar_Categoria()
        {
            // Arrange
            var id = _categoria.IdCategoria;
            _mockRepo.Setup(repo => repo.RecuperaCategoriaPorIdAsync(id)).ReturnsAsync(_categoria);

            // Act
            var result = await _mockRepo.Object.RecuperaCategoriaPorIdAsync(id);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_categoria, result);
        }

        [Fact]
        public async Task RecuperaCategoriasAsync_Deve_Retornar_Lista_De_Categorias()
        {
            // Arrange
            var categorias = new List<Categoria> { _categoria };
            _mockRepo.Setup(repo => repo.RecuperaCategoriasAsync()).ReturnsAsync(categorias);

            // Act
            var result = await _mockRepo.Object.RecuperaCategoriasAsync();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);           
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_categoria, result.FirstOrDefault());
        }
    }
}
