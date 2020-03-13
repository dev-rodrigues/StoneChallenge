using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stone.Infrastructure.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Setor = table.Column<string>(nullable: true),
                    SalarioBruto = table.Column<long>(nullable: false),
                    Admissao = table.Column<DateTime>(nullable: false),
                    PlanoSaude = table.Column<bool>(nullable: false),
                    PlanoDental = table.Column<bool>(nullable: false),
                    ValeTransporte = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
