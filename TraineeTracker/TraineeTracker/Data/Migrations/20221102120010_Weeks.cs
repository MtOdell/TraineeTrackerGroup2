using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeTracker.Data.Migrations
{
    public partial class Weeks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "TrackerDB",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Week",
                table: "TrackerDB");
        }
    }
}
