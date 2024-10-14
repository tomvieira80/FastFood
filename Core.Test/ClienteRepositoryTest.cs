using Domain.Models;
using Domain.Repositories;
using Domain.Validators;
using Moq;
using System.Text.Json;
using Xunit;


namespace Core.Test
{

    public class ClienteRepositoryTest
    {
        private readonly Mock<IClienteRepository> _mockRepo;
        private readonly Mock<IClienteValidator> _mockValidator;
        private readonly Cliente _cliente;

        public ClienteRepositoryTest()
        {
            _mockRepo = new Mock<IClienteRepository>();
            _mockValidator = new Mock<IClienteValidator>();

            _cliente = new Cliente
            {
                IdCliente = Guid.NewGuid(),
                Nome = "João Silva",
                CPF = "12345678900",
                Email = "joao.silva@example.com",
                DataAlteracao = DateTime.Now,
                Ativo = true
            };
        }

        [Fact]
        public async Task IncluiClienteAsync_Deve_Incluir_Cliente()
        {
            _mockRepo.Setup(repo => repo.IncluiClienteAsync(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            await _mockRepo.Object.IncluiClienteAsync(_cliente);

            _mockRepo.Verify(repo => repo.IncluiClienteAsync(_cliente), Times.Once);
        }

        [Fact]
        public async Task RecuperaClientePorIdAsync_Deve_Retornar_Cliente()
        {
            _mockRepo.Setup(repo => repo.RecuperaClientePorIdAsync(It.IsAny<Guid>())).ReturnsAsync(_cliente);

            var result = await _mockRepo.Object.RecuperaClientePorIdAsync(_cliente.IdCliente);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_cliente, result);
        }

        [Fact]
        public async Task EditaClienteAsync_Deve_Editar_Cliente()
        {
            _mockRepo.Setup(repo => repo.EditaClienteAsync(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            await _mockRepo.Object.EditaClienteAsync(_cliente);

            _mockRepo.Verify(repo => repo.EditaClienteAsync(_cliente), Times.Once);
        }

        [Fact]
        public async Task RecuperaClientePorCPFAsync_Deve_Retornar_Cliente()
        {

            _mockRepo.Setup(repo => repo.RecuperaClientePorCPFAsync(It.IsAny<string>())).ReturnsAsync(_cliente);

            var result = await _mockRepo.Object.RecuperaClientePorCPFAsync("12345678900");
                   
            
            Console.WriteLine(JsonSerializer.Serialize(result));
           

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_cliente.CPF, result.CPF);

          
        }

        [Fact]
        public async Task AtivarInativarClienteAsync_Deve_Atualizar_Status_Cliente()
        {
            _mockRepo.Setup(repo => repo.AtivarInativarClienteAsync(It.IsAny<Guid>(), It.IsAny<bool>())).Returns(Task.CompletedTask);

            Console.WriteLine(JsonSerializer.Serialize(_cliente));

            await _mockRepo.Object.AtivarInativarClienteAsync(_cliente.IdCliente, false);

            Console.WriteLine(JsonSerializer.Serialize(_cliente));

            _mockRepo.Verify(repo => repo.AtivarInativarClienteAsync(_cliente.IdCliente, false), Times.Once);
        }

        [Fact]
        public async Task ValidarClienteAsync_Deve_Validar_Dados_cliente()
        {
            _mockValidator.Setup(repo => repo.Validate(It.IsAny<Cliente>(), out It.Ref<List<string>>.IsAny)).Returns(true);

            var validarCliente = _mockValidator.Object.Validate(_cliente, out var errors);

            Console.WriteLine(JsonSerializer.Serialize(validarCliente));

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(validarCliente);
        }

        [Fact]
        public async Task ValidarClienteAsync_Com_Erro_Validar_Dados_cliente()
        {
            _mockValidator.Setup(repo => repo.Validate(It.IsAny<Cliente>(), out It.Ref<List<string>>.IsAny)).Returns(false);

            var cliente = new Cliente
            {
                IdCliente = Guid.NewGuid(),
                Nome = "",
                CPF = "",
                Email = "",
                DataAlteracao = DateTime.Now,
                Ativo = true
            };

            var validarCliente = _mockValidator.Object.Validate(cliente, out var errors);

            Console.WriteLine(JsonSerializer.Serialize(validarCliente));

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(validarCliente);
        }





    }
}
