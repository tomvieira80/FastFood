using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public interface IPedidoItemValidator
    {
        bool Validate(PedidoItem pedidoItem, out List<string> errors);
    }
}
