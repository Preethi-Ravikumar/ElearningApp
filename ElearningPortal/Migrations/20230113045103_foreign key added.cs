using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElearningPortal.Migrations
{
    public partial class foreignkeyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserModelUserId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserModelUserId",
                table: "Courses",
                column: "UserModelUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_UserModels_UserModelUserId",
                table: "Courses",
                column: "UserModelUserId",
                principalTable: "UserModels",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_UserModels_UserModelUserId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserModelUserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserModelUserId",
                table: "Courses");
        }
    }
}
