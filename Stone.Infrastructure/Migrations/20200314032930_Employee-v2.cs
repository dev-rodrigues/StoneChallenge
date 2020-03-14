using Microsoft.EntityFrameworkCore.Migrations;

namespace Stone.Infrastructure.Migrations
{
    public partial class Employeev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SalarioBruto",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SalarioBruto",
                table: "Employees",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
