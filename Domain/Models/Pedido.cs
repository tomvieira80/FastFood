using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pedido
{
    [Key]
    public Guid IdPedido { get; set; }

    public Guid IdCliente { get; set; }

    [ForeignKey("IdCliente")]
    public Cliente Cliente { get; set; }

    [Required]
    public int NumeroPedido { get; set; }

    public Guid IdPedidoStatus { get; set; }

    [ForeignKey("IdPedidoStatus")]
    public PedidoStatus PedidoStatus { get; set; }

    [Required]
    [Column(TypeName = "timestamp(6)")]
    public DateTime DataCriacao { get; set; }

    [Required]
    [Column(TypeName = "timestamp(6)")]
    public DateTime DataAlteracao { get; set; }

    public ICollection<PedidoItem> PedidoItens { get; set; }
}

