using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarZ.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityOrResort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityOrResort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    BeginningOfTheWorkDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndOfTheWorkDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookPageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityOrResortId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bar_CityOrResort_CityOrResortId",
                        column: x => x.CityOrResortId,
                        principalTable: "CityOrResort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bar_CityOrResortId",
                table: "Bar",
                column: "CityOrResortId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bar");

            migrationBuilder.DropTable(
                name: "CityOrResort");
        }
    }
}
