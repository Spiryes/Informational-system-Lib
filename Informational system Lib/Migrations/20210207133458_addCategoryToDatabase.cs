using Microsoft.EntityFrameworkCore.Migrations;

namespace Informational_system_Lib.Migrations
{
    public partial class addCategoryToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IdBook = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zaglavie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avtor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Janr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kolichestvo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IdBook);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
