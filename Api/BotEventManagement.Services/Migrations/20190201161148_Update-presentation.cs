using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManager.Services.Migrations
{
    public partial class Updatepresentation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "EventManager",
                table: "Presentation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Local",
                schema: "EventManager",
                table: "Presentation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                schema: "EventManager",
                table: "Presentation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "EventManager",
                table: "Presentation");

            migrationBuilder.DropColumn(
                name: "Local",
                schema: "EventManager",
                table: "Presentation");

            migrationBuilder.DropColumn(
                name: "Theme",
                schema: "EventManager",
                table: "Presentation");
        }
    }
}
