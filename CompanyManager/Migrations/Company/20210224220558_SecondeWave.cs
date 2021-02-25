using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManager.Migrations.Company
{
    public partial class SecondeWave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NumeroDeChapa = table.Column<int>(nullable: false),
                    Ddd1 = table.Column<int>(nullable: true),
                    Telefone1 = table.Column<int>(nullable: true),
                    Ddd2 = table.Column<int>(nullable: true),
                    Telefone2 = table.Column<int>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lideres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lideres", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Lideres");
        }
    }
}
