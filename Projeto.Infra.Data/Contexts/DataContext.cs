using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    //Regra 1: Herdar a classe DbContext do EF
    public class DataContext : DbContext
    {
        //Regra 2: Criar um construtor
        //Este construtor irá receber como parametro um objeto da connectionString
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) //Enviando o parametro para o construtor da Superclasse ou classe pai
        {

        }

        //Regra 3: Criar um set/get(DbSet) para cada entidade
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        //Regra 4: Sobreescrever o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //neste método iremos incluir cada classe mapeada no projeto
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            //configurar o campo email como unique
            modelBuilder.Entity<Usuario>(entity => { entity.HasIndex(u => u.Email).IsUnique(); });
        }
    }
}
