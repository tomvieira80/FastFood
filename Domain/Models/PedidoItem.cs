using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PedidoItem
{
    [Key]
    public Guid IdPedidoItem { get; set; }

    public Guid IdPedido { get; set; }

    [ForeignKey("IdPedido")]
    public Pedido Pedido { get; set; }

    public Guid IdProduto { get; set; }

    [ForeignKey("IdProduto")]
    public Produto Produto { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    public bool Ativo { get; set; }

    [Required]
    [Column(TypeName = "timestamp(6)")]
    public DateTime DataAlteracao { get; set; }
}