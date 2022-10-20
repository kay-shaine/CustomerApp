using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerWebAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "PhoneNumber" },
                values: new object[] { 1, "kehinde.enigbokan@wemabank.com", "Kehinde", "/Images/Beauty/Beauty1.png", "Enigbokan", 7053201384L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "PhoneNumber" },
                values: new object[] { 2, "hasan.daranijo@wemabank.com", "Hassan", "/Images/Beauty/Beauty2.png", "Daranijo", 8168301935L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "PhoneNumber" },
                values: new object[] { 3, "tosin.peters@wemabank.com", "Tosin", "/Images/Beauty/Beauty3.png", "Peters", 8053518772L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
