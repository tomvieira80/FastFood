using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FastFood.API.Dtos
{
    public class PedidoItensList
    {
        public Guid IdPedido { get; set; }
        public int NumeroPedido { get; set; }
        public string Cliente { get; set; }
        public string Status { get; set; }

        public IEnumerable<Item> Itens { get; set; } = new List<Item>();

        public class Item
        {
            public Guid IdPedidoItem { get; set; }         

            public Guid IdProduto { get; set; }
           
            public string NomeProduto { get; set; }
           
            public int Quantidade { get; set; }

            public float PrecoUnitario { get; set; }
        }
    }
}
