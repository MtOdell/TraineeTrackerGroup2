using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

namespace TraineeTracker.Data.Migrations
{
    [ExcludeFromCodeCoverage]

    public partial class Levels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackerDB_UserDataDB_userDataID",
                table: "TrackerDB");

            migrationBuilder.RenameColumn(
                name: "userDataID",
                table: "TrackerDB",
                newName: "UserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_TrackerDB_userDataID",
                table: "TrackerDB",
                newName: "IX_TrackerDB_UserDataId");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserDataDB",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Education",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Activity",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "UserDataDB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserDataDB_UserID",
                table: "UserDataDB",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackerDB_UserDataDB_UserDataId",
                table: "TrackerDB",
                column: "UserDataId",
                principalTable: "UserDataDB",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDataDB_AspNetUsers_UserID",
                table: "UserDataDB",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackerDB_UserDataDB_UserDataId",
                table: "TrackerDB");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDataDB_AspNetUsers_UserID",
                table: "UserDataDB");

            migrationBuilder.DropIndex(
                name: "IX_UserDataDB_UserID",
                table: "UserDataDB");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "UserDataDB");

            migrationBuilder.RenameColumn(
                name: "UserDataId",
                table: "TrackerDB",
                newName: "userDataID");

            migrationBuilder.RenameIndex(
                name: "IX_TrackerDB_UserDataId",
                table: "TrackerDB",
                newName: "IX_TrackerDB_userDataID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Education",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Activity",
                table: "UserDataDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackerDB_UserDataDB_userDataID",
                table: "TrackerDB",
                column: "userDataID",
                principalTable: "UserDataDB",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
