using System.ComponentModel.DataAnnotations;

namespace FastFood.API.Dtos
{
    public class ClienteInsert
    {
        
        [Required(ErrorMessage = "Informe o seu nome")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Nome deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu CPF")]        
        [Range(0, Int64.MaxValue, ErrorMessage = "CPF deve conter apenas numeros")]
        [StringLength(10, ErrorMessage = "CPF deve conter no maximo 10 digitos")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Email deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string Email { get; set; }
    }
}
