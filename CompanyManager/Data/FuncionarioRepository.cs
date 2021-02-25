using CompanyManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManager.Data
{
    public class FuncionarioRepository
    {
        public bool CreateFuncionario(Funcionario funcionario)
        {
            using(var _context = new CompanyContext())
            {
                try
                {
                    _context.Funcionarios.Add(funcionario);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
