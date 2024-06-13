using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzeria_manager.Migrations
{
    /// <inheritdoc />
    public partial class columnImageByte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFile",
                table: "Pizze",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Pizze");
        }
    }
}
