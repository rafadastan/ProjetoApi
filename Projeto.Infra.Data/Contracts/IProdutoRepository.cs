using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contracts
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        List<Produto> GetByNome(string nome);
        List<Produto> GetByPreco(decimal precoIni, decimal precoFim);
    }
}
