using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Repositories;
using Moq;
using Xunit;

namespace Core.Test
{
    public class PedidoRepositoryTest
    {
        private readonly Mock<IPedidoRepository> _mockRepo;
        private readonly Pedido _pedido;

        public PedidoRepositoryTest()
        {
            _mockRepo = new Mock<IPedidoRepository>();

            _pedido = new Pedido
            {
                IdPedido = Guid.NewGuid(),
                IdCliente = Guid.NewGuid(),
                NumeroPedido = 1234,
                IdPedidoStatus = Guid.NewGuid(),
                DataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                PedidoItens = new List<PedidoItem>()
            };
        }

        [Fact]
        public async Task IncluiPedidoAsync_Deve_Incluir_Pedido()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.IncluiPedidoAsync(It.IsAny<Pedido>())).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.IncluiPedidoAsync(_pedido);

            // Assert
            _mockRepo.Verify(repo => repo.IncluiPedidoAsync(_pedido), Times.Once);
        }

        [Fact]
        public async Task AlterarStatusPedidoAsync_Deve_Alterar_Status()
        {
            // Arrange
            var id = _pedido.IdPedido;
            var novoStatus = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.AlterarStatusPedidoAsync(id, novoStatus)).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.AlterarStatusPedidoAsync(id, novoStatus);

            // Assert
            _mockRepo.Verify(repo => repo.AlterarStatusPedidoAsync(id, novoStatus), Times.Once);
        }

        [Fact]
        public async Task RecuperaPedidoPorIdAsync_Deve_Retornar_Pedido()
        {
            // Arrange
            var id = _pedido.IdPedido;
            _mockRepo.Setup(repo => repo.RecuperaPedidoPorIdAsync(id)).ReturnsAsync(_pedido);

            // Act
            var result = await _mockRepo.Object.RecuperaPedidoPorIdAsync(id);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_pedido, result);
        }

        [Fact]
        public async Task RecuperaPedidoPorNrPedidoAsync_Deve_Retornar_Pedido()
        {
            // Arrange
            var numeroPedido = _pedido.NumeroPedido;
            _mockRepo.Setup(repo => repo.RecuperaPedidoPorNrPedidoAsync(numeroPedido)).ReturnsAsync(_pedido);

            // Act
            var result = await _mockRepo.Object.RecuperaPedidoPorNrPedidoAsync(numeroPedido);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_pedido, result);
        }

        [Fact]
        public async Task RecuperaPedidosAsync_Deve_Retornar_Lista_De_Pedidos()
        {
            // Arrange
            var pedidos = new List<Pedido> { _pedido };
            _mockRepo.Setup(repo => repo.RecuperaPedidosAsync()).ReturnsAsync(pedidos);

            // Act
            var result = await _mockRepo.Object.RecuperaPedidosAsync();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        }


    }
}
