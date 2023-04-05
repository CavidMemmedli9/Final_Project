using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class JobInfoDeletLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyResponse",
                table: "JobInfo");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "JobInfo",
                newName: "Company");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Company",
                table: "JobInfo",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "KeyResponse",
                table: "JobInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
