using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class RestoreeJobINFO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "JobInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobInfo_CityId",
                table: "JobInfo",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobInfo_City_CityId",
                table: "JobInfo",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobInfo_City_CityId",
                table: "JobInfo");

            migrationBuilder.DropIndex(
                name: "IX_JobInfo_CityId",
                table: "JobInfo");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "JobInfo");
        }
    }
}
