using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XUnit.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    MSSV = table.Column<string>(maxLength: 9, nullable: false),
                    HoTen = table.Column<string>(maxLength: 50, nullable: false),
                    GioiTinh = table.Column<bool>(nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: true),
                    DiaChi = table.Column<string>(maxLength: 250, nullable: true),
                    SoDienThoai = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.MSSV);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfStudy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHocPhan = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfStudy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassOfStudyUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MSSV = table.Column<string>(maxLength: 9, nullable: false),
                    IdUnitOfStudy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassOfStudyUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassOfStudyUnit_UnitOfStudy_IdUnitOfStudy",
                        column: x => x.IdUnitOfStudy,
                        principalTable: "UnitOfStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassOfStudyUnit_Student_MSSV",
                        column: x => x.MSSV,
                        principalTable: "Student",
                        principalColumn: "MSSV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassOfStudyUnit_IdUnitOfStudy",
                table: "ClassOfStudyUnit",
                column: "IdUnitOfStudy");

            migrationBuilder.CreateIndex(
                name: "IX_ClassOfStudyUnit_MSSV",
                table: "ClassOfStudyUnit",
                column: "MSSV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassOfStudyUnit");

            migrationBuilder.DropTable(
                name: "UnitOfStudy");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
