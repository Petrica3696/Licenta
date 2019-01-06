using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Write.Configurations.Entities
{
    public class ProductConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CategoryId)
                .IsRequired();

            builder.Property(p => p.Username)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired();
        }
    }
}
