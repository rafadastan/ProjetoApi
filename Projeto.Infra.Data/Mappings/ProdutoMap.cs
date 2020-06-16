using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //nome da tabela
            builder.ToTable("Produto");

            //chave primária
            builder.HasKey(p => p.IdProduto);

            //mapear os campos da tabela
            builder.Property(p => p.IdProduto)
                .HasColumnName("IdProduto");

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("Preco")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            builder.Property(p => p.IdFornecedor)
                .HasColumnName("IdFornecedor")
                .IsRequired();

            //Mapeamento do relacionamento(1 para muitos)
            //Produto tem um 1 fornecedor / Fornecedor TEM MUITOS Produtos
            builder.HasOne(p => p.Fornecedor) //Produto TEM 1 fornecedor
                .WithMany(f => f.produtos) //Fornecedor TEM MUITOS Produtos
                .HasForeignKey(p=>p.IdFornecedor); //Chave estrangeira
        }
    }
}
