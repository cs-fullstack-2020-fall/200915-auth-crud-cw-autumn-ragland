using Microsoft.EntityFrameworkCore.Migrations;

namespace Classwork.Data.Migrations
{
    public partial class BooksInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(maxLength: 100, nullable: false),
                    author = table.Column<string>(nullable: false),
                    isbn = table.Column<int>(nullable: false),
                    isBestSeller = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
