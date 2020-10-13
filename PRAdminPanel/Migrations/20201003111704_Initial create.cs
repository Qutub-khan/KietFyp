using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRAdminPanel.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNumber = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    ProductCategory = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
