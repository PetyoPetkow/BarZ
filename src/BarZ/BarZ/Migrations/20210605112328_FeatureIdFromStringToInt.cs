using Microsoft.EntityFrameworkCore.Migrations;

namespace BarZ.Migrations
{
    public partial class FeatureIdFromStringToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarFeature_Features_FeatureId1",
                table: "BarFeature");

            migrationBuilder.DropIndex(
                name: "IX_BarFeature_FeatureId1",
                table: "BarFeature");

            migrationBuilder.DropColumn(
                name: "FeatureId1",
                table: "BarFeature");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureId",
                table: "BarFeature",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_BarFeature_FeatureId",
                table: "BarFeature",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarFeature_Features_FeatureId",
                table: "BarFeature",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarFeature_Features_FeatureId",
                table: "BarFeature");

            migrationBuilder.DropIndex(
                name: "IX_BarFeature_FeatureId",
                table: "BarFeature");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureId",
                table: "BarFeature",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FeatureId1",
                table: "BarFeature",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BarFeature_FeatureId1",
                table: "BarFeature",
                column: "FeatureId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BarFeature_Features_FeatureId1",
                table: "BarFeature",
                column: "FeatureId1",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
