using System.ComponentModel.DataAnnotations;

namespace FastFood.API.Dtos
{
    public class ClienteUpdate
    {      
        public string Nome { get; set; }        
        public string CPF { get; set; }       
        public string Email { get; set; }
        public bool Ativo { get; set; }

    }
}
