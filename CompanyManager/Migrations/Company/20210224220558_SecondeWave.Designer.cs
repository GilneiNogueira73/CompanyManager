﻿// <auto-generated />
using System;
using CompanyManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyManager.Migrations.Company
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20210224220558_SecondeWave")]
    partial class SecondeWave
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyManager.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Ddd1")
                        .HasColumnType("int");

                    b.Property<int?>("Ddd2")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDeChapa")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telefone1")
                        .HasColumnType("int");

                    b.Property<int?>("Telefone2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("CompanyManager.Models.Lider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Lideres");
                });
#pragma warning restore 612, 618
        }
    }
}
