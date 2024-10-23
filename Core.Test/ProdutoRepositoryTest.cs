using Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Core.Test
{
    public class ProdutoRepositoryTest
    {
        private readonly Mock<IProdutoRepository> _mockRepo;
        private readonly Produto _produto;

        public ProdutoRepositoryTest()
        {
            _mockRepo = new Mock<IProdutoRepository>();

            _produto = new Produto
            {
                IdProduto = Guid.NewGuid(),
                NomeProduto = "Produto A",
                DataAlteracao = DateTime.Now,
                Ativo = true,
                Preco = 10.5f,
                IdCategoria = Guid.NewGuid(),
                Categoria = new Categoria { IdCategoria = Guid.NewGuid(), NomeCategoria = "Categoria A" },
                PedidoItens = new List<PedidoItem>()
            };
        }

        [Fact]
        public async Task IncluiProdutoAsync_Deve_Incluir_Produto()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.IncluiProdutoAsync(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.IncluiProdutoAsync(_produto);

            // Assert
            _mockRepo.Verify(repo => repo.IncluiProdutoAsync(_produto), Times.Once);
        }

        [Fact]
        public async Task EditaProdutoAsync_Deve_Editar_Produto()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.EditaProdutoAsync(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.EditaProdutoAsync(_produto);

            // Assert
            _mockRepo.Verify(repo => repo.EditaProdutoAsync(_produto), Times.Once);
        }

        [Fact]
        public async Task AtivarInativarProdutoAsync_Deve_Alterar_Status()
        {
            // Arrange
            var id = _produto.IdProduto;
            var novoStatus = false;
            _mockRepo.Setup(repo => repo.AtivarInativarProdutoAsync(id, novoStatus)).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.AtivarInativarProdutoAsync(id, novoStatus);

            // Assert
            _mockRepo.Verify(repo => repo.AtivarInativarProdutoAsync(id, novoStatus), Times.Once);
        }

        [Fact]
        public async Task RecuperaProdutoPorIdAsync_Deve_Retornar_Produto()
        {
            // Arrange
            var id = _produto.IdProduto;
            _mockRepo.Setup(repo => repo.RecuperaProdutoPorIdAsync(id)).ReturnsAsync(_produto);

            // Act
            var result = await _mockRepo.Object.RecuperaProdutoPorIdAsync(id);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_produto, result);
        }

        [Fact]
        public async Task RecuperaProdutosAsync_Deve_Retornar_Lista_De_Produtos()
        {
            // Arrange
            var produtos = new List<Produto> { _produto };
            _mockRepo.Setup(repo => repo.RecuperaProdutosAsync()).ReturnsAsync(produtos);

            // Act
            var result = await _mockRepo.Object.RecuperaProdutosAsync();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);

        }
    }
}
