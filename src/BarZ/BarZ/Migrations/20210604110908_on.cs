using Microsoft.EntityFrameworkCore.Migrations;

namespace BarZ.Migrations
{
    public partial class on : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarFeature_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarFeature_Feature_FeatureId1",
                        column: x => x.FeatureId1,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarFeature_BarId",
                table: "BarFeature",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_BarFeature_FeatureId1",
                table: "BarFeature",
                column: "FeatureId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarFeature");

            migrationBuilder.DropTable(
                name: "Feature");
        }
    }
}
