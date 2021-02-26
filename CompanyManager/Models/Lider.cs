using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManager.Models
{
    public class Lider
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FuncionarioId { get; set; }
        public bool Excluido { get; set; }

    }
}
