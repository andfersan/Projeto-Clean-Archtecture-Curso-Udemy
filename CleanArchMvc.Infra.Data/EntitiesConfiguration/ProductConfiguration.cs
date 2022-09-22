using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            // Precisão de 10 com duas casas decimais.
            builder.Property(p => p.Price).HasPrecision(10,2);
            // Mapeamento de relacionamento um para muitos de categorias e produtos, com chave estrangeira CategoryId.
            builder.HasOne(e => e.Category).WithMany(e => e.Products)
                   .HasForeignKey(e => e.CategoryId);
        }
    }
}
