namespace FastFood.API.Dtos
{
    public class PedidoItemUpdate
    {
        public Guid IdPedido { get; set; }

        public Guid IdProduto { get; set; }

        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
    }
}
