using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstrumentShop.Data.Migrations
{
    public partial class migrate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BildSource",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BildSource",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Products");
        }
    }
}
