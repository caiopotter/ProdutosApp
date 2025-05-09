using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Produto.
    /// </summary>
    internal class ProdutoMap: IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(p => p.Quantidade)
                .IsRequired();
            builder.Property(p => p.DataHoraCriacao)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.Ativo)
                .IsRequired();
            builder.Property(p => p.CategoriaId)
                .IsRequired();
            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
