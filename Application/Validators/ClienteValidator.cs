using Domain.Models;
using Domain.Repositories;
using Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ClienteValidator : IClienteValidator
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteValidator(IClienteRepository clienteRepository) 
        {
            _clienteRepository = clienteRepository;
        }
        public bool Validate(Cliente cliente, bool novoCliente, out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrWhiteSpace(cliente.Nome))
                errors.Add("Nome é obrigatório.");

            if (!IsValidCPF(cliente.CPF))
                errors.Add("CPF inválido, deve conter apenas números e 9 posições.");

            if(novoCliente)
                if (IsCPFJaCadastrado(cliente.CPF))
                    errors.Add("CPF já cadastrado na base.");

            if (!IsValidEmail(cliente.Email))
                errors.Add("Email inválido.");

            // Outras validações

            return errors.Count == 0;
        }

        private bool IsValidCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            var regex = new Regex(@"^\d{9,}$");
            return regex.IsMatch(cpf);
        }

        private bool IsCPFJaCadastrado(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            var jaCadastrado =  _clienteRepository.CPFJaCadastrado(cpf);           

            return jaCadastrado;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
