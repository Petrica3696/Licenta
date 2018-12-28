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

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasData(
                new Product
                {
                    Id = new Guid("fa234822-e6c6-417b-9230-a3ccaac3rog2"),
                    CategoryId = new Guid("da234822-e6c6-417b-9230-a3categ3fed0"),
                    UserId = new Guid("da234822-e6c6-417b-9230-a3cuser3use1"),
                    Name = "Product 1",
                    Description = "Description 1",
                    StartPrice = 100,
                    LowLimitPrice = 150,
                    IsSold = false
                },
                new Product
                {
                    Id = new Guid("fa234822-e6c6-417b-9230-a3ccaac3rog3"),
                    CategoryId = new Guid("da234822-e6c6-417b-9230-a3categ3fed1"),
                    UserId = new Guid("da234822-e6c6-417b-9230-a3cuser3use2"),
                    Name = "Product 2",
                    Description = "Description 2",
                    StartPrice = 200,
                    LowLimitPrice = 450,
                    IsSold = false
                },
                new Product
                {
                    Id = new Guid("fa234822-e6c6-417b-9230-a3ccaac3rog2"),
                    CategoryId = new Guid("da234822-e6c6-417b-9230-a3categ3fed2"),
                    UserId = new Guid("da234822-e6c6-417b-9230-a3cuser3use3"),
                    Name = "Product 3",
                    Description = "Description 3",
                    StartPrice = 300,
                    LowLimitPrice = 550,
                    IsSold = false
                }
                );
        }
    }
}
