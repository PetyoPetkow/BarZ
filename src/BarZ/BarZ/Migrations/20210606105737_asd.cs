using Microsoft.EntityFrameworkCore.Migrations;

namespace BarZ.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarFeature_Bars_BarId",
                table: "BarFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_BarFeature_Features_FeatureId",
                table: "BarFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarFeature",
                table: "BarFeature");

            migrationBuilder.RenameTable(
                name: "BarFeature",
                newName: "BarsFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_BarFeature_FeatureId",
                table: "BarsFeatures",
                newName: "IX_BarsFeatures_FeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_BarFeature_BarId",
                table: "BarsFeatures",
                newName: "IX_BarsFeatures_BarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarsFeatures",
                table: "BarsFeatures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarsFeatures_Bars_BarId",
                table: "BarsFeatures",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarsFeatures_Features_FeatureId",
                table: "BarsFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarsFeatures_Bars_BarId",
                table: "BarsFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_BarsFeatures_Features_FeatureId",
                table: "BarsFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarsFeatures",
                table: "BarsFeatures");

            migrationBuilder.RenameTable(
                name: "BarsFeatures",
                newName: "BarFeature");

            migrationBuilder.RenameIndex(
                name: "IX_BarsFeatures_FeatureId",
                table: "BarFeature",
                newName: "IX_BarFeature_FeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_BarsFeatures_BarId",
                table: "BarFeature",
                newName: "IX_BarFeature_BarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarFeature",
                table: "BarFeature",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarFeature_Bars_BarId",
                table: "BarFeature",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarFeature_Features_FeatureId",
                table: "BarFeature",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
