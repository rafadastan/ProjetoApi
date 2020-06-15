using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            //Tabela do banco
            builder.ToTable("Fornecedor");

            //Chave primaria da tabela(primary key)
            builder.HasKey(f => f.IdFornecedor);

            //Mapeando cada atributo do campo da tabela
            builder.Property(f => f.IdFornecedor)
                .HasColumnName("IdFornecedor");

            builder.Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cnpj)
                .HasColumnName("Cnpj")
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
