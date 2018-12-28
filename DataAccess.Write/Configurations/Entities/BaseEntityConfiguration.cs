using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Write.Configurations.Entities
{
    public abstract class BaseEntityConfiguration
    {
        public void Configure<T>(EntityTypeBuilder<T> builder)
            where T : BaseEntity
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired();
        }
    }
}
