using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzeria_manager.Migrations
{
    /// <inheritdoc />
    public partial class aggiungiTabellaIngredienti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Ingredienti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientiPizza",
                columns: table => new
                {
                    IngredientiId = table.Column<int>(type: "int", nullable: false),
                    PizzeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientiPizza", x => new { x.IngredientiId, x.PizzeId });
                    table.ForeignKey(
                        name: "FK_IngredientiPizza_Ingredienti_IngredientiId",
                        column: x => x.IngredientiId,
                        principalTable: "Ingredienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientiPizza_Pizze_PizzeId",
                        column: x => x.PizzeId,
                        principalTable: "Pizze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientiPizza_PizzeId",
                table: "IngredientiPizza",
                column: "PizzeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientiPizza");

            migrationBuilder.DropTable(
                name: "Ingredienti");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");
        }
    }
}
