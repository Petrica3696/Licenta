using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Write.Configurations.Entities
{
    public class CategoryConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired();
        }
    }
}
