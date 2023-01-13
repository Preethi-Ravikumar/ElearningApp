using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElearningPortal.Migrations
{
    public partial class isActiveaddedinuserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "isActive",
                table: "UserModels",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "UserModels");
        }
    }
}
