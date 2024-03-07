using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_CODE_SERIES.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRelationshipStudent_Evaluation_Nullkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("2b557ddc-1b9a-4082-99cf-8004a6a4ab62"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("4ed991cb-4ede-41ae-b640-369ad5b7d5c4"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("8e272370-493f-488b-8c0c-a229a5d309ef"));

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    AdditionalExplanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_Evaluation_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("28630baf-cf7c-44fe-880f-638bed7700ff"), 34, "Anu" },
                    { new Guid("433f126b-89f9-41c2-91fd-4848b5c14e96"), 1, "Adrian" },
                    { new Guid("e4c18021-bd7d-4c05-bf67-90ac6972dc84"), 40, "Anish" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_StudentId",
                table: "Evaluation",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("28630baf-cf7c-44fe-880f-638bed7700ff"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("433f126b-89f9-41c2-91fd-4848b5c14e96"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("e4c18021-bd7d-4c05-bf67-90ac6972dc84"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("2b557ddc-1b9a-4082-99cf-8004a6a4ab62"), 34, "Anu" },
                    { new Guid("4ed991cb-4ede-41ae-b640-369ad5b7d5c4"), 40, "Anish" },
                    { new Guid("8e272370-493f-488b-8c0c-a229a5d309ef"), 1, "Adrian" }
                });
        }
    }
}
