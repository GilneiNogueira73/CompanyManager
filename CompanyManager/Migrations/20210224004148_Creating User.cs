﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManager.Migrations
{
    public partial class CreatingUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers]" + "values" + "('a80a64fe-186c-4ebb-953d-bf02f3c16256','admin@companymanager.com','ADMIN@COMPANYMANAGER.COM','admin@companymanager.com','ADMIN@COMPANYMANAGER.COM',0,'AQAAAAEAACcQAAAAEOIQbbYAJDrIZ+nYIqLckMHYngQOuMQ//IvL1KQIyPmTvYekdk4feqBaESzfasVWmA==','AORLPOEAAOXP3E2JG4QZCPY2R5U4ZEOM','9a705fa3-90ef-4877-b1a8-b296006f0476',null,0,0,null,1,0,'Gerente','Silva')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Funcionarios]" + "values" + "('E0964E1D-529C-4168-940E-99644413F690','pedro','da Silva','pedro@companymanager.com',1,47,999999999,null,null,123456,'pedro',0,null)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
