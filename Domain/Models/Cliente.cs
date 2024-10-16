using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Cliente
    {
        [Key]
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "timestamp(6)")]
        public DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

    }
}
