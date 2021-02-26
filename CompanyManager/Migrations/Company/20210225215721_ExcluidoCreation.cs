using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManager.Migrations.Company
{
    public partial class ExcluidoCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Lideres",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Funcionarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LiderId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Lideres");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "LiderId",
                table: "Funcionarios");
        }
    }
}
