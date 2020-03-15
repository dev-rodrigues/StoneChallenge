using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stone.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    SobreNome = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    Setor = table.Column<string>(nullable: false),
                    SalarioBruto = table.Column<decimal>(nullable: false),
                    Admissao = table.Column<DateTime>(nullable: false),
                    PlanoSaude = table.Column<bool>(nullable: false),
                    PlanoDental = table.Column<bool>(nullable: false),
                    ValeTransporte = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Minimo = table.Column<decimal>(nullable: false),
                    Maximo = table.Column<decimal>(nullable: false),
                    Alicota = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Irpf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Minimo = table.Column<decimal>(nullable: false),
                    Maximo = table.Column<decimal>(nullable: false),
                    Alicota = table.Column<decimal>(nullable: false),
                    Deduzir = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irpf", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Inss");

            migrationBuilder.DropTable(
                name: "Irpf");
        }
    }
}
