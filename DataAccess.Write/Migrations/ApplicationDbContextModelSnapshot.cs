﻿// <auto-generated />
using System;
using DataAccess.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Write.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = new Guid("da234822-e6c6-417b-9230-a3ccaac3fed0"), Name = "Category 1" },
                        new { Id = new Guid("09c1a2e6-7721-4db8-b789-0ed4cf98635b"), Name = "Category 2" },
                        new { Id = new Guid("e4cd9efc-886a-4d4a-b3b5-164047f6daa3"), Name = "Category 3" },
                        new { Id = new Guid("e21206d5-d1e9-4b92-ae92-52115991c69f"), Name = "Category 4" },
                        new { Id = new Guid("1fb5480a-d53f-497d-886b-62c8ced740ed"), Name = "Category 5" }
                    );
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryId")
                        .IsRequired();

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<double?>("FinalPrice");

                    b.Property<bool>("IsSold");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("StartPrice");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.Property<string>("WinnerId");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Token");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
