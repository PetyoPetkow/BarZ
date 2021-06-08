using Microsoft.EntityFrameworkCore.Migrations;

namespace BarZ.Migrations
{
    public partial class plsWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarFeature",
                columns: table => new
                {
                    BarsId = table.Column<int>(type: "int", nullable: false),
                    FeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarFeature", x => new { x.BarsId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_BarFeature_Bars_BarsId",
                        column: x => x.BarsId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarFeature_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarFeature_FeaturesId",
                table: "BarFeature",
                column: "FeaturesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarFeature");
        }
    }
}
