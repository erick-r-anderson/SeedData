using Microsoft.EntityFrameworkCore.Migrations;

namespace SeedData.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "seeds");

            migrationBuilder.CreateTable(
                name: "color",
                schema: "seeds",
                columns: table => new
                {
                    idcolor = table.Column<int>(type: "int(11)", nullable: false),
                        
                    color = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_color", x => x.idcolor);
                });

            migrationBuilder.CreateTable(
                name: "month",
                schema: "seeds",
                columns: table => new
                {
                    idmonth = table.Column<int>(type: "int(11)", nullable: false),
                     
                    month = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_month", x => x.idmonth);
                });

            migrationBuilder.CreateTable(
                name: "seed",
                schema: "seeds",
                columns: table => new
                {
                    seedId = table.Column<int>(type: "int(11)", nullable: false),
                        
                    scientificName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    commonName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    prairie = table.Column<byte>(type: "tinyint(4)", nullable: true),
                    savanna = table.Column<byte>(type: "tinyint(4)", nullable: true),
                    woodland = table.Column<byte>(type: "tinyint(4)", nullable: true),
                    dry = table.Column<byte>(type: "tinyint(4)", nullable: true),
                    drymesic = table.Column<byte>(type: "tinyint(4)", nullable: true),
                    mesic = table.Column<byte>(type: "tinyint(4)", nullable: true),
                    wetmesic = table.Column<byte>(type: "tinyint(4)", nullable: true),
                    wet = table.Column<byte>(type: "tinyint(4)", nullable: true),
                    color1Id = table.Column<int>(type: "int(11)", nullable: true),
                    startMonthId = table.Column<int>(type: "int(11)", nullable: true),
                    endMonthId = table.Column<int>(type: "int(11)", nullable: true),
                    bloomMonthId = table.Column<int>(type: "int(11)", nullable: true),
                    color2Id = table.Column<int>(type: "int(11)", nullable: true),
                    color3Id = table.Column<int>(type: "int(11)", nullable: true),
                    bloomMonthEndId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seed", x => x.seedId);
                    table.ForeignKey(
                        name: "fk_monthbloomend",
                        column: x => x.bloomMonthEndId,
                        principalSchema: "seeds",
                        principalTable: "month",
                        principalColumn: "idmonth",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_monthbloom",
                        column: x => x.bloomMonthId,
                        principalSchema: "seeds",
                        principalTable: "month",
                        principalColumn: "idmonth",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_color",
                        column: x => x.color1Id,
                        principalSchema: "seeds",
                        principalTable: "color",
                        principalColumn: "idcolor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_color2",
                        column: x => x.color2Id,
                        principalSchema: "seeds",
                        principalTable: "color",
                        principalColumn: "idcolor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_color3",
                        column: x => x.color3Id,
                        principalSchema: "seeds",
                        principalTable: "color",
                        principalColumn: "idcolor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_monthend",
                        column: x => x.endMonthId,
                        principalSchema: "seeds",
                        principalTable: "month",
                        principalColumn: "idmonth",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_monthstart",
                        column: x => x.startMonthId,
                        principalSchema: "seeds",
                        principalTable: "month",
                        principalColumn: "idmonth",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_monthbloomend_idx",
                schema: "seeds",
                table: "seed",
                column: "bloomMonthEndId");

            migrationBuilder.CreateIndex(
                name: "fk_monthbloom_idx",
                schema: "seeds",
                table: "seed",
                column: "bloomMonthId");

            migrationBuilder.CreateIndex(
                name: "fk_color_idx",
                schema: "seeds",
                table: "seed",
                column: "color1Id");

            migrationBuilder.CreateIndex(
                name: "fk_color2_idx",
                schema: "seeds",
                table: "seed",
                column: "color2Id");

            migrationBuilder.CreateIndex(
                name: "fk_color3_idx",
                schema: "seeds",
                table: "seed",
                column: "color3Id");

            migrationBuilder.CreateIndex(
                name: "fk_monthend_idx",
                schema: "seeds",
                table: "seed",
                column: "endMonthId");

            migrationBuilder.CreateIndex(
                name: "fk_monthstart_idx",
                schema: "seeds",
                table: "seed",
                column: "startMonthId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "seed",
                schema: "seeds");

            migrationBuilder.DropTable(
                name: "month",
                schema: "seeds");

            migrationBuilder.DropTable(
                name: "color",
                schema: "seeds");
        }
    }
}
