using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session3.DAL.Presistance.Data.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreateDateOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
