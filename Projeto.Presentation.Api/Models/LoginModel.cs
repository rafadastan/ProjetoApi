using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public string Senha { get; set; }

    }
}
