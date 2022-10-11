using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Informational_system_Lib.Migrations.Customer
{
    public partial class addCustomerToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "nvarchar(max)", nullable: false),
                    EGN = table.Column<int>(type: "nvarchar(max)", nullable: false),
                    NameOfBook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeregistration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
