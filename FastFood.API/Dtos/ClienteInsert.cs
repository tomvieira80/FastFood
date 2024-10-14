using System.ComponentModel.DataAnnotations;

namespace FastFood.API.Dtos
{
    public class ClienteInsert
    {    
        public string Nome { get; set; }        
        public string CPF { get; set; }       
        public string Email { get; set; }
    }
}
