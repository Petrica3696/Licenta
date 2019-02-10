using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Write.Configurations.Entities
{
    public class WishlistConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.ProductId)
                .IsRequired();
        }
    }
}
