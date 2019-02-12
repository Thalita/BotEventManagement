using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManager.Services.Migrations
{
    public partial class AddEventIdinAttendant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                schema: "EventManager",
                table: "Attendant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendant_EventId",
                schema: "EventManager",
                table: "Attendant",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendant_Event_EventId",
                schema: "EventManager",
                table: "Attendant",
                column: "EventId",
                principalSchema: "EventManager",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendant_Event_EventId",
                schema: "EventManager",
                table: "Attendant");

            migrationBuilder.DropIndex(
                name: "IX_Attendant_EventId",
                schema: "EventManager",
                table: "Attendant");

            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "EventManager",
                table: "Attendant");
        }
    }
}
