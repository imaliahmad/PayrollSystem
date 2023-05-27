using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.DAL.Migrations
{
    public partial class addeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentDeptId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentDeptId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeptId",
                table: "Employee",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DeptId",
                table: "Employee",
                column: "DeptId",
                principalTable: "Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DeptId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DeptId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDeptId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentDeptId",
                table: "Employee",
                column: "DepartmentDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentDeptId",
                table: "Employee",
                column: "DepartmentDeptId",
                principalTable: "Department",
                principalColumn: "DeptId");
        }
    }
}
