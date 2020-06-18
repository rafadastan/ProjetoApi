using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        private DataContext dataContext;

        public FornecedorRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Fornecedor GetByCnpj(string cnpj)
        {
            return dataContext.Fornecedor
                .FirstOrDefault(f=>f.Equals(cnpj));
        }
    }
}
