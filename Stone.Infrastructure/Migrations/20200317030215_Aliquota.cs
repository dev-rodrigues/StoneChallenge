using Microsoft.EntityFrameworkCore.Migrations;

namespace Stone.Infrastructure.Migrations
{
    public partial class Aliquota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Alicota",
                table: "Irpf",
                newName: "Aliquota");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Aliquota",
                table: "Irpf",
                newName: "Alicota");
        }
    }
}
