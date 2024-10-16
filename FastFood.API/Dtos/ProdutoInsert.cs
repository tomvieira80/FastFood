namespace FastFood.API.Dtos
{
    public class ProdutoInsert
    {
        public string NomeProduto { get; set; }
        public float Preco { get; set; }
        public Guid IdCategoria { get; set; }
    }
}
