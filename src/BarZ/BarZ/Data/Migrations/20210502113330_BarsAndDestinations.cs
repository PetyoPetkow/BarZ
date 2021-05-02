using Microsoft.EntityFrameworkCore.Migrations;

namespace BarZ.Data.Migrations
{
    public partial class BarsAndDestinations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bar_CityOrResort_CityOrResortId",
                table: "Bar");

            migrationBuilder.DropTable(
                name: "CityOrResort");

            migrationBuilder.RenameColumn(
                name: "CityOrResortId",
                table: "Bar",
                newName: "DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Bar_CityOrResortId",
                table: "Bar",
                newName: "IX_Bar_DestinationId");

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bar_Destination_DestinationId",
                table: "Bar",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bar_Destination_DestinationId",
                table: "Bar");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "Bar",
                newName: "CityOrResortId");

            migrationBuilder.RenameIndex(
                name: "IX_Bar_DestinationId",
                table: "Bar",
                newName: "IX_Bar_CityOrResortId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bar_CityOrResort_CityOrResortId",
                table: "Bar",
                column: "CityOrResortId",
                principalTable: "CityOrResort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
