using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManager.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public int NumeroDeChapa { get; set; }
        public int? Ddd1 { get; set; }
        public int? Telefone1 { get; set; }
        public int? Ddd2 { get; set; }
        public int? Telefone2 { get; set; }
        public Guid LiderId { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
    }
}
