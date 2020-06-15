using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Models
{
    public class ProdutoEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do produto.")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public string Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public string Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o fornecedor do produto.")]
        public int IdFornecedor { get; set; }

    }
}
