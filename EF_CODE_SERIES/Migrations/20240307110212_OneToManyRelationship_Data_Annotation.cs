using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_CODE_SERIES.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRelationship_Data_Annotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("25c76ef1-bf0b-4e7d-9ab9-5136c3653651"), 40, "Anish" },
                    { new Guid("84ddd250-835e-4136-b04a-260d6583077c"), 1, "Adrian" },
                    { new Guid("991e87ea-c22f-45be-a766-60541fb32ae0"), 34, "Anu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("25c76ef1-bf0b-4e7d-9ab9-5136c3653651"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("84ddd250-835e-4136-b04a-260d6583077c"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("991e87ea-c22f-45be-a766-60541fb32ae0"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("28630baf-cf7c-44fe-880f-638bed7700ff"), 34, "Anu" },
                    { new Guid("433f126b-89f9-41c2-91fd-4848b5c14e96"), 1, "Adrian" },
                    { new Guid("e4c18021-bd7d-4c05-bf67-90ac6972dc84"), 40, "Anish" }
                });
        }
    }
}
