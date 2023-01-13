using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElearningPortal.Migrations
{
    public partial class isverifiedattributeaddedincoursetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserModels",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserModels",
                newName: "UserId");

            migrationBuilder.AddColumn<byte>(
                name: "isVerified",
                table: "Courses",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVerified",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserModels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserModels",
                newName: "Id");
        }
    }
}
