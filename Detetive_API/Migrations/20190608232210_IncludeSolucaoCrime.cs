using Microsoft.EntityFrameworkCore.Migrations;

namespace Detetive_API.Migrations
{
    public partial class IncludeSolucaoCrime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolucaoCrimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SuspeitoId = table.Column<int>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    ArmaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolucaoCrimes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolucaoCrimes");
        }
    }
}
