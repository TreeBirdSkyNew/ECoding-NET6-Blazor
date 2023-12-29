using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_CODING_DAL.Migrations
{
    public partial class AddingEFExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemplateSolution",
                columns: table => new
                {
                    TemplateSolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateProjectId = table.Column<int>(type: "int", nullable: false),
                    TemplateSolutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateSolutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateSolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateSolutionVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateSolutionVersionNet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateSolution", x => x.TemplateSolutionId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProject",
                columns: table => new
                {
                    TemplateProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectVersionNet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateSolutionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProject", x => x.TemplateProjectId);
                    table.ForeignKey(
                        name: "FK_TemplateProject_TemplateSolution_TemplateSolutionId",
                        column: x => x.TemplateSolutionId,
                        principalTable: "TemplateSolution",
                        principalColumn: "TemplateSolutionId");
                });

            migrationBuilder.CreateTable(
                name: "TemplateResult",
                columns: table => new
                {
                    TemplateResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateResultName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateResult", x => x.TemplateResultId);
                    table.ForeignKey(
                        name: "FK_TemplateResult_TemplateProject_TemplateProjectId",
                        column: x => x.TemplateProjectId,
                        principalTable: "TemplateProject",
                        principalColumn: "TemplateProjectId");
                });

            migrationBuilder.CreateTable(
                name: "TemplateTechnique",
                columns: table => new
                {
                    TemplateTechniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateTechniqueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTechnique", x => x.TemplateTechniqueId);
                    table.ForeignKey(
                        name: "FK_TemplateTechnique_TemplateProject_TemplateProjectId",
                        column: x => x.TemplateProjectId,
                        principalTable: "TemplateProject",
                        principalColumn: "TemplateProjectId");
                });

            migrationBuilder.CreateTable(
                name: "TemplateResultItem",
                columns: table => new
                {
                    TemplateResultItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateResultId = table.Column<int>(type: "int", nullable: true),
                    TemplateTechniqueId = table.Column<int>(type: "int", nullable: false),
                    TemplateFonctionnelId = table.Column<int>(type: "int", nullable: false),
                    TemplateResultItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultItemVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultItemVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultInitialContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultFinalContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateResultItem", x => x.TemplateResultItemId);
                    table.ForeignKey(
                        name: "FK_TemplateResultItem_TemplateResult_TemplateResultId",
                        column: x => x.TemplateResultId,
                        principalTable: "TemplateResult",
                        principalColumn: "TemplateResultId");
                });

            migrationBuilder.CreateTable(
                name: "TechniqueParameter",
                columns: table => new
                {
                    TechniqueParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechniqueParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechniqueParameterValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniqueParameter", x => x.TechniqueParameterId);
                    table.ForeignKey(
                        name: "FK_TechniqueParameter_TemplateTechnique_TemplateTechniqueId",
                        column: x => x.TemplateTechniqueId,
                        principalTable: "TemplateTechnique",
                        principalColumn: "TemplateTechniqueId");
                });

            migrationBuilder.CreateTable(
                name: "TemplateTechniqueItem",
                columns: table => new
                {
                    TemplateTechniqueItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateTechniqueId = table.Column<int>(type: "int", nullable: true),
                    TemplateTechniqueItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueItemVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueItemVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueInitialFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueFinalContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTechniqueItem", x => x.TemplateTechniqueItemId);
                    table.ForeignKey(
                        name: "FK_TemplateTechniqueItem_TemplateTechnique_TemplateTechniqueId",
                        column: x => x.TemplateTechniqueId,
                        principalTable: "TemplateTechnique",
                        principalColumn: "TemplateTechniqueId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechniqueParameter_TemplateTechniqueId",
                table: "TechniqueParameter",
                column: "TemplateTechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProject_TemplateSolutionId",
                table: "TemplateProject",
                column: "TemplateSolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateResult_TemplateProjectId",
                table: "TemplateResult",
                column: "TemplateProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateResultItem_TemplateResultId",
                table: "TemplateResultItem",
                column: "TemplateResultId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTechnique_TemplateProjectId",
                table: "TemplateTechnique",
                column: "TemplateProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTechniqueItem_TemplateTechniqueId",
                table: "TemplateTechniqueItem",
                column: "TemplateTechniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechniqueParameter");

            migrationBuilder.DropTable(
                name: "TemplateResultItem");

            migrationBuilder.DropTable(
                name: "TemplateTechniqueItem");

            migrationBuilder.DropTable(
                name: "TemplateResult");

            migrationBuilder.DropTable(
                name: "TemplateTechnique");

            migrationBuilder.DropTable(
                name: "TemplateProject");

            migrationBuilder.DropTable(
                name: "TemplateSolution");
        }
    }
}
