using Domain.Models;
using Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ProdutoValidator : IProdutoValidator
    {
        public bool Validate(Produto produto, out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrWhiteSpace(produto.NomeProduto))
                errors.Add("Nome do produto é obrigatório.");

            if (produto.Preco < 1)
                errors.Add("O valor não pode ser negativo e deve ser superior a 0.");

            return errors.Count == 0;
        }




    }
}
