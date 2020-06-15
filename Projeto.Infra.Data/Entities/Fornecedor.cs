using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Entities
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public List<Produto> produtos { get; set; }
    }
}
