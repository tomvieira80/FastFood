using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
