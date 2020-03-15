using Microsoft.EntityFrameworkCore.Migrations;

namespace Stone.Infrastructure.Migrations
{
    public partial class irffdeduzir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Deduzir",
                table: "Irff",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deduzir",
                table: "Irff");
        }
    }
}
