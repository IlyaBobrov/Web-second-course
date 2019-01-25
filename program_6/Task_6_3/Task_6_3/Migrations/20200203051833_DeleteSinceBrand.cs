using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_6_3.Migrations
{
    public partial class DeleteSinceBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Since",
                table: "Brands");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Since",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
