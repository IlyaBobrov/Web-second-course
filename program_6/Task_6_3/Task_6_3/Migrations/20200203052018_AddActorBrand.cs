using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_6_3.Migrations
{
    public partial class AddActorBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actor",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actor",
                table: "Brands");
        }
    }
}
