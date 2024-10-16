using Domain.Models;

namespace Domain.Validators
{
    public interface IProdutoValidator
    {
        bool Validate(Produto produto, out List<string> errors);
    }
}

