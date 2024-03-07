using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_CODE_SERIES.Migrations
{
    /// <inheritdoc />
    public partial class johnz_007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.StudentId);
                });
            migrationBuilder.Sql(@"create procedure sp_johnzFirst as select * from student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");
            migrationBuilder.Sql(@"drop procedure sp_johnzFirst");
        }
    }
}
