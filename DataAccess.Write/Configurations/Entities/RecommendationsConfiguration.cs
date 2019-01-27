using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Write.Configurations.Entities
{
    public class RecommendationsConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Recommendations>
    {
        public void Configure(EntityTypeBuilder<Recommendations> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CategoryId)
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired();
        }
    }
}
