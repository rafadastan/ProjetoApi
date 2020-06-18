using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contracts
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor>
    {
        Fornecedor GetByCnpj(string cnpj);
    }
}
