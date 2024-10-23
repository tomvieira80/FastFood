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
    public class PedidoItemRepositoryTest
    {
        private readonly Mock<IPedidoItemRepository> _mockRepo;
        private readonly PedidoItem _pedidoItem;

        public PedidoItemRepositoryTest()
        {
            _mockRepo = new Mock<IPedidoItemRepository>();

            _pedidoItem = new PedidoItem
            {
                IdPedidoItem = Guid.NewGuid(),
                IdPedido = Guid.NewGuid(),
                IdProduto = Guid.NewGuid(),
                Quantidade = 10,
                Ativo = true,
                DataAlteracao = DateTime.Now
            };
        }

        [Fact]
        public async Task IncluiPedidoItemAsync_Deve_Incluir_PedidoItem()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.IncluiPedidoItemAsync(It.IsAny<PedidoItem>())).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.IncluiPedidoItemAsync(_pedidoItem);

            // Assert
            _mockRepo.Verify(repo => repo.IncluiPedidoItemAsync(_pedidoItem), Times.Once);
        }

        [Fact]
        public async Task EditaPedidoItemAsync_Deve_Editar_PedidoItem()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.EditaPedidoItemAsync(It.IsAny<PedidoItem>())).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.EditaPedidoItemAsync(_pedidoItem);

            // Assert
            _mockRepo.Verify(repo => repo.EditaPedidoItemAsync(_pedidoItem), Times.Once);
        }

        [Fact]
        public async Task AtivarInativarPedidoItemAsync_Deve_Alterar_Status()
        {
            // Arrange
            var id = _pedidoItem.IdPedidoItem;
            var novoStatus = false;
            _mockRepo.Setup(repo => repo.AtivarInativarPedidoItemAsync(id, novoStatus)).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.AtivarInativarPedidoItemAsync(id, novoStatus);

            // Assert
            _mockRepo.Verify(repo => repo.AtivarInativarPedidoItemAsync(id, novoStatus), Times.Once);
        }

        [Fact]
        public async Task RecuperaPedidoItemPorIdAsync_Deve_Retornar_PedidoItem()
        {
            // Arrange
            var id = _pedidoItem.IdPedidoItem;
            _mockRepo.Setup(repo => repo.RecuperaPedidoItemPorIdAsync(id)).ReturnsAsync(_pedidoItem);

            // Act
            var result = await _mockRepo.Object.RecuperaPedidoItemPorIdAsync(id);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_pedidoItem, result);
        }

        [Fact]
        public async Task RecuperaPedidoItemAtivoPorIdPedidoAsync_Deve_Retornar_Lista_De_PedidoItens()
        {
            // Arrange
            var idPedido = _pedidoItem.IdPedido;
            var pedidoItens = new List<PedidoItem> { _pedidoItem };
            _mockRepo.Setup(repo => repo.RecuperaPedidoItemAtivoPorIdPedidoAsync(idPedido)).ReturnsAsync(pedidoItens);

            // Act
            var result = await _mockRepo.Object.RecuperaPedidoItemAtivoPorIdPedidoAsync(idPedido);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);

        }

        [Fact]
        public async Task RecuperaPedidoItensAsync_Deve_Retornar_Lista_De_PedidoItens()
        {
            // Arrange
            var pedidoItens = new List<PedidoItem> { _pedidoItem };
            _mockRepo.Setup(repo => repo.RecuperaPedidoItensAsync()).ReturnsAsync(pedidoItens);

            // Act
            var result = await _mockRepo.Object.RecuperaPedidoItensAsync();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        }
    }
}
