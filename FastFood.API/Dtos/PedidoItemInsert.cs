using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FastFood.API.Dtos
{
    public class PedidoItemInsert
    {
        public Guid IdPedido { get; set; }
                
        public Guid IdProduto { get; set; }               
        
        public int Quantidade { get; set; }
        
    }
}
