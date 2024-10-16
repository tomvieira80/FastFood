using System.Reflection.Metadata.Ecma335;

namespace FastFood.API.Dtos
{
    public class ProdutoUpdate
    {
        public string NomeProduto { get; set; }
        public float Preco { get; set; }
        public Guid IdCategoria { get; set; }
        public bool Ativo { get; set; }
    }
}
