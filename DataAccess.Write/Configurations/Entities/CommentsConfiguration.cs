using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Write.Configurations.Entities
{
    public class CommentsConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ProductId)
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired();
            builder.Property(p => p.Text)
                .IsRequired();
            builder.Property(p => p.PostDate)
                .IsRequired();
        }
    }
}
