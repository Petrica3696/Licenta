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

            builder.HasData(
                new Category
                {
                    Id = new Guid("da234822-e6c6-417b-9230-a3ccaac3fed0"),
                    Name = "Category 1"
                },
                new Category
                {
                    Id = new Guid("09c1a2e6-7721-4db8-b789-0ed4cf98635b"),
                    Name = "Category 2"
                },
                new Category
                {
                    Id = new Guid("e4cd9efc-886a-4d4a-b3b5-164047f6daa3"),
                    Name = "Category 3"
                },
                new Category
                {
                    Id = new Guid("e21206d5-d1e9-4b92-ae92-52115991c69f"),
                    Name = "Category 4"
                },
                new Category
                {
                    Id = new Guid("1fb5480a-d53f-497d-886b-62c8ced740ed"),
                    Name = "Category 5"
                }
                );
        }
    }
}
