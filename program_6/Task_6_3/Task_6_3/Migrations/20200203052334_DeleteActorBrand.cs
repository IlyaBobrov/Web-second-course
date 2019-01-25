using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_6_3.Migrations
{
    public partial class DeleteActorBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actor",
                table: "Brands");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actor",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
