using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteParsing.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixEntityEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodeModel",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeModel",
                table: "Equipment");
        }
    }
}
