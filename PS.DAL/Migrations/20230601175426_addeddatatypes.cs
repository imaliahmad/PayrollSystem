using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.DAL.Migrations
{
    public partial class addeddatatypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Attendence",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Batch",
                table: "Attendence",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lecture",
                table: "Attendence",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Section",
                table: "Attendence",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendence_EmpId",
                table: "Attendence",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendence_Employee_EmpId",
                table: "Attendence",
                column: "EmpId",
                principalTable: "Employee",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendence_Employee_EmpId",
                table: "Attendence");

            migrationBuilder.DropIndex(
                name: "IX_Attendence_EmpId",
                table: "Attendence");

            migrationBuilder.DropColumn(
                name: "Batch",
                table: "Attendence");

            migrationBuilder.DropColumn(
                name: "Lecture",
                table: "Attendence");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Attendence");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Attendence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
