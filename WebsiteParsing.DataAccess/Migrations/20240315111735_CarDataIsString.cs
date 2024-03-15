using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteParsing.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CarDataIsString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateRange",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRange",
                table: "Cars",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
