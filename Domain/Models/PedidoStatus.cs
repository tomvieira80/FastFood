using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PedidoStatus
{
    [Key]
    public Guid IdPedidoStatus { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    [Column(TypeName = "timestamp(6)")]
    public DateTime DataAlteracao { get; set; }

    [Required]
    public bool Ativo { get; set; }

    public ICollection<Pedido> Pedidos { get; set; }
}