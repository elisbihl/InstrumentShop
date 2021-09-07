using Microsoft.EntityFrameworkCore.Migrations;

namespace InstrumentShop.Data.Migrations
{
    public partial class migrate62123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CatImg",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatImg",
                table: "Categories");
        }
    }
}
