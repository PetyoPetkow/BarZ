using Microsoft.EntityFrameworkCore.Migrations;

namespace BarZ.Data.Migrations
{
    public partial class BarViewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bar_Destination_DestinationId",
                table: "Bar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destination",
                table: "Destination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bar",
                table: "Bar");

            migrationBuilder.RenameTable(
                name: "Destination",
                newName: "Destinations");

            migrationBuilder.RenameTable(
                name: "Bar",
                newName: "Bars");

            migrationBuilder.RenameIndex(
                name: "IX_Bar_DestinationId",
                table: "Bars",
                newName: "IX_Bars_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bars",
                table: "Bars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_Destinations_DestinationId",
                table: "Bars",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bars_Destinations_DestinationId",
                table: "Bars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bars",
                table: "Bars");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Destination");

            migrationBuilder.RenameTable(
                name: "Bars",
                newName: "Bar");

            migrationBuilder.RenameIndex(
                name: "IX_Bars_DestinationId",
                table: "Bar",
                newName: "IX_Bar_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destination",
                table: "Destination",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bar",
                table: "Bar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bar_Destination_DestinationId",
                table: "Bar",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
