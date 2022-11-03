using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

namespace TraineeTracker.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackerDB_AspNetUsers_TraineeID",
                table: "TrackerDB");

            migrationBuilder.DropTable(
                name: "ProfileDB");

            migrationBuilder.DropIndex(
                name: "IX_TrackerDB_TraineeID",
                table: "TrackerDB");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TraineeID",
                table: "TrackerDB");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Trainer_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Trainer_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Week",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "userDataID",
                table: "TrackerDB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserDataDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDataDB", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackerDB_userDataID",
                table: "TrackerDB",
                column: "userDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackerDB_UserDataDB_userDataID",
                table: "TrackerDB",
                column: "userDataID",
                principalTable: "UserDataDB",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackerDB_UserDataDB_userDataID",
                table: "TrackerDB");

            migrationBuilder.DropTable(
                name: "UserDataDB");

            migrationBuilder.DropIndex(
                name: "IX_TrackerDB_userDataID",
                table: "TrackerDB");

            migrationBuilder.DropColumn(
                name: "userDataID",
                table: "TrackerDB");

            migrationBuilder.AddColumn<string>(
                name: "TraineeID",
                table: "TrackerDB",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trainer_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trainer_LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfileDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileDB", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackerDB_TraineeID",
                table: "TrackerDB",
                column: "TraineeID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TrainerId",
                table: "AspNetUsers",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TrainerId",
                table: "AspNetUsers",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackerDB_AspNetUsers_TraineeID",
                table: "TrackerDB",
                column: "TraineeID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
