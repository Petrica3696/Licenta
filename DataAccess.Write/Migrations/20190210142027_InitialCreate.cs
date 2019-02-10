using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Write.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
                    WinnerId = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    StartPrice = table.Column<double>(nullable: false),
                    FinalPrice = table.Column<double>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: false),
                    IsSold = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("da234822-e6c6-417b-9230-a3ccaac3fed0"), "Category 1" },
                    { new Guid("09c1a2e6-7721-4db8-b789-0ed4cf98635b"), "Category 2" },
                    { new Guid("e4cd9efc-886a-4d4a-b3b5-164047f6daa3"), "Category 3" },
                    { new Guid("e21206d5-d1e9-4b92-ae92-52115991c69f"), "Category 4" },
                    { new Guid("1fb5480a-d53f-497d-886b-62c8ced740ed"), "Category 5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
