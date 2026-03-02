using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avto.Market.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarModelWithImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_path",
                table: "cars",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_path",
                table: "cars");
        }
    }
}
