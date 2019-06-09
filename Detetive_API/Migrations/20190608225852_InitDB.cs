using Microsoft.EntityFrameworkCore.Migrations;

namespace Detetive_API.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suspeitos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspeitos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Cajado Devastador" });

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Phaser" });

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Peixeira" });

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 4, "Trezoitão" });

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 5, "Sabre de Luz" });

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 6, "Bomba" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 10, "São Paulo" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 9, "Show do Katinguele" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 8, "Machu Picchu" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 7, "Sibéria" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 6, "Nova York" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 5, "Gotham" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 4, "Springfield" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Tatooine" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Vulcano" });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Etérnia" });

            migrationBuilder.InsertData(
                table: "Suspeitos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Esqueleto" });

            migrationBuilder.InsertData(
                table: "Suspeitos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Khan" });

            migrationBuilder.InsertData(
                table: "Suspeitos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Dath Vader" });

            migrationBuilder.InsertData(
                table: "Suspeitos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 4, "Sideshow Bob" });

            migrationBuilder.InsertData(
                table: "Suspeitos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 5, "Coringa" });

            migrationBuilder.InsertData(
                table: "Suspeitos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 6, "Duende Verde" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.DropTable(
                name: "Suspeitos");
        }
    }
}
