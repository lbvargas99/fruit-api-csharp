using Fruit.Crud.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit.Crud.Core.Infra.Data.Maps
{
    internal class FruitMap : IEntityTypeConfiguration<Domain.Entities.Fruit>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Fruit> builder)
        {
            builder.ToTable("fruta");
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("idfruta")
                .UseIdentityColumn();

            builder.Property(f => f.Description)
                .HasColumnName("descricao");

            builder.Property(f => f.ValueA)
                .HasColumnName("valora");
            
            builder.Property(f => f.ValueB)
                .HasColumnName("valorb");
        }
    }
}
