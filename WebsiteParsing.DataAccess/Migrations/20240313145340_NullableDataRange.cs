using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteParsing.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NullableDataRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelName_ModelCode_DateRange",
                table: "Cars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRange",
                table: "Cars",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelName_ModelCode_DateRange",
                table: "Cars",
                columns: new[] { "ModelName", "ModelCode", "DateRange" },
                unique: true,
                filter: "[DateRange] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelName_ModelCode_DateRange",
                table: "Cars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRange",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelName_ModelCode_DateRange",
                table: "Cars",
                columns: new[] { "ModelName", "ModelCode", "DateRange" },
                unique: true);
        }
    }
}
