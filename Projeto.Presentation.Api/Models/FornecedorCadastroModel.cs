using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Models
{
    public class FornecedorCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do fornecedor.")]
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cnpj do fornecedor.")]
        public string Cnpj { get; set; }
    }
}
