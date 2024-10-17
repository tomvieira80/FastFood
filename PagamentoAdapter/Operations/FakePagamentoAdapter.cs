using Domain.Services;
using Microsoft.Extensions.Logging;

namespace PagamentoAdapter.Operations
{
    public class FakePagamentoAdapter : IPagamentoService
    {
        private readonly ILogger<FakePagamentoAdapter> _logger;

        public FakePagamentoAdapter(ILogger<FakePagamentoAdapter> logger)
        {
            _logger = logger;
        }

        public bool ValidarPagamento(Guid idPagamento)
        {
            _logger.LogInformation("Validou o pagamento");

            // a ser desenvolvido na proximas disciplinas

            return true;
        }
    }
}
