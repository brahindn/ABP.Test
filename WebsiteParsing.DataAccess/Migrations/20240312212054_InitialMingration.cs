using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteParsing.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMingration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelCode = table.Column<int>(type: "int", nullable: false),
                    DateRange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GearShiftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cab = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransmissionModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadingCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelName_ModelCode_DateRange",
                table: "Cars",
                columns: new[] { "ModelName", "ModelCode", "DateRange" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CarId",
                table: "Equipment",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentName",
                table: "Equipment",
                column: "EquipmentName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
