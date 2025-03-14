using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSessionEFcore3.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDepartmentView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create or alter view EmployeeDepartmentView
                                       with encryption 
                                       as
                                       select E.Id EmployeeId, E.EmpName EmployeeName,D.Id DepartmentId,D.Name DepartmentName
                                       from Employee2s E join Departments D 
                                       on E.DepartmentId=D.Id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop view EmployeeDepartmentView");

        }
    }
}
