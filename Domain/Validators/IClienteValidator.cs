using Domain.Models;

namespace Domain.Validators
{
    public interface IClienteValidator
    {
        bool Validate(Cliente cliente, bool novoCliente, out List<string> errors);
    }
}
