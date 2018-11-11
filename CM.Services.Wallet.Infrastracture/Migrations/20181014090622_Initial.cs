using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CM.Services.Wallet.Infrastracture.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Wallet");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Wallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "Wallet");
        }
    }
}
