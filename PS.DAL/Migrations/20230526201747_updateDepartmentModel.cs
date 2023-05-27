using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.DAL.Migrations
{
    public partial class updateDepartmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DeptId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DeptId",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNo",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
