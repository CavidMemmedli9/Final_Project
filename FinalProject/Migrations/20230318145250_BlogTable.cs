using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class BlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_BlogId",
                table: "Articles",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Blog_BlogId",
                table: "Articles",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Blog_BlogId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Articles_BlogId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Articles");
        }
    }
}
