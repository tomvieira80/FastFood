using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Produto
{
    [Key]
    public Guid IdProduto { get; set; }

    [Required]
    public string NomeProduto { get; set; }

    [Required]
    [Column(TypeName = "timestamp(6)")]
    public DateTime DataAlteracao { get; set; }

    [Required]
    public bool Ativo { get; set; }
    [Required]
    public float Preco { get; set; }

    public Guid IdCategoria { get; set; }

    [ForeignKey("IdCategoria")]
    public Categoria Categoria { get; set; }

    public ICollection<PedidoItem> PedidoItens { get; set; }
}