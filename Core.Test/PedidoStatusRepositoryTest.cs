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
    public class PedidoStatusRepositoryTest
    {
        private readonly Mock<IPedidoStatusRepository> _mockRepo;
        private readonly PedidoStatus _pedidoStatus;

        public PedidoStatusRepositoryTest()
        {
            _mockRepo = new Mock<IPedidoStatusRepository>();

            _pedidoStatus = new PedidoStatus
            {
                IdPedidoStatus = Guid.NewGuid(),
                Status = "Enviado",
                DataAlteracao = DateTime.Now,
                Ativo = true,
                Pedidos = new List<Pedido>()
            };
        }

        [Fact]
        public async Task RecuperaPedidoStatusPorIdAsync_Deve_Retornar_PedidoStatus()
        {
            // Arrange
            var id = _pedidoStatus.IdPedidoStatus;
            _mockRepo.Setup(repo => repo.RecuperaPedidoStatusPorIdAsync(id)).ReturnsAsync(_pedidoStatus);

            // Act
            var result = await _mockRepo.Object.RecuperaPedidoStatusPorIdAsync(id);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_pedidoStatus, result);
        }

        [Fact]
        public async Task RecuperaPedidoStatusAsync_Deve_Retornar_Lista_De_PedidoStatus()
        {
            // Arrange
            var pedidoStatuses = new List<PedidoStatus> { _pedidoStatus };
            _mockRepo.Setup(repo => repo.RecuperaPedidoStatusAsync()).ReturnsAsync(pedidoStatuses);

            // Act
            var result = await _mockRepo.Object.RecuperaPedidoStatusAsync();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);          
        }
    }
}
