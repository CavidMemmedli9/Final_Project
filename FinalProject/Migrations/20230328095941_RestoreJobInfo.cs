using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class RestoreJobInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "JobInfo");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "JobInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobInfo_CategoryId",
                table: "JobInfo",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobInfo_Category_CategoryId",
                table: "JobInfo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobInfo_Category_CategoryId",
                table: "JobInfo");

            migrationBuilder.DropIndex(
                name: "IX_JobInfo_CategoryId",
                table: "JobInfo");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "JobInfo");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "JobInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
