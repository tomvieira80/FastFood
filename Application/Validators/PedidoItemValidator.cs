using Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class PedidoItemValidator : IPedidoItemValidator
    {
        public bool Validate(PedidoItem pedidoItem, out List<string> errors)
        {
            errors = new List<string>();

            if (pedidoItem.Quantidade < 1)
                errors.Add("A quantidade não pode ser negativo e deve ser superior a 0.");

            return errors.Count == 0;
        }
    }
}
