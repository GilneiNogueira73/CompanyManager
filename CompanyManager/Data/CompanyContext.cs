using CompanyManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManager.Data
{
    public class CompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CompanyManager;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Lider> Lideres { get; set; }

    }
}
