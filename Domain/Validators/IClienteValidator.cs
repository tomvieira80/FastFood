using Domain.Models;

namespace Domain.Validators
{
    public interface IClienteValidator
    {
        bool Validate(Cliente cliente, out List<string> errors);
    }
}
