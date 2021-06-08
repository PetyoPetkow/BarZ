using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarZ.Migrations
{
    public partial class Features : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarFeature_Feature_FeatureId1",
                table: "BarFeature");

            migrationBuilder.DropTable(
                name: "BarViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feature",
                table: "Feature");

            migrationBuilder.RenameTable(
                name: "Feature",
                newName: "Features");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Features",
                table: "Features",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarFeature_Features_FeatureId1",
                table: "BarFeature",
                column: "FeatureId1",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarFeature_Features_FeatureId1",
                table: "BarFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Features",
                table: "Features");

            migrationBuilder.RenameTable(
                name: "Features",
                newName: "Feature");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feature",
                table: "Feature",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BarViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginningOfTheWorkDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationId = table.Column<int>(type: "int", nullable: true),
                    EndOfTheWorkDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacebookPageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAdress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarViewModel_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarViewModel_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarViewModel_DestinationId",
                table: "BarViewModel",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_BarViewModel_ImageId",
                table: "BarViewModel",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarFeature_Feature_FeatureId1",
                table: "BarFeature",
                column: "FeatureId1",
                principalTable: "Feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
