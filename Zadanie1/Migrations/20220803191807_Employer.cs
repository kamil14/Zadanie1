using Microsoft.EntityFrameworkCore.Migrations;

namespace Zadanie1.Migrations
{
    public partial class Employer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nip = table.Column<string>(nullable: true),
                    StatusVat = table.Column<string>(nullable: true),
                    Regon = table.Column<string>(nullable: true),
                    ResidenceAddress = table.Column<string>(nullable: true),
                    RegistrationLegalDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employers");
        }
    }
}
