using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private DataContext dataContext;

        public ProdutoRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public override List<Produto> GetAll()
        {
            return dataContext.Produto
                .Include(p => p.Fornecedor)
                .ToList();
        }

        public override Produto GetById(int id)
        {
            return dataContext.Produto
                .Include(p => p.Fornecedor)
                .FirstOrDefault(p => p.IdProduto == id);
        }

        public List<Produto> GetByNome(string nome)
        {
            return dataContext.Produto
                .Include(p => p.Fornecedor)
                .Where(p => p.Nome.Contains(nome))
                .ToList();
        }

        public List<Produto> GetByPreco(decimal precoIni, decimal precoFim)
        {
            return dataContext.Produto
                .Include(p => p.Fornecedor)
                .Where(p => p.Preco >= precoIni && p.Preco <= precoFim)
                .ToList();
        }
    }
}
