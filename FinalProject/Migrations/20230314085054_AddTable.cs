using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Statics",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statics",
                table: "Statics",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Statics",
                table: "Statics");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Statics");
        }
    }
}
