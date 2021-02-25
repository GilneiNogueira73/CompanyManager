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

        public bool EditFuncionario(Funcionario funcionario)
        {
            if (funcionario.Id == null)
            {
                return false;
            }
            using (var _context = new CompanyContext())
            {
                try
                {
                    Funcionario funcionarioEditado = _context.Funcionarios.Find(funcionario.Id);
                    funcionarioEditado.Ddd1 = funcionario.Ddd1;
                    funcionarioEditado.Ddd2 = funcionario.Ddd2;
                    funcionarioEditado.Email = funcionario.Email;
                    funcionarioEditado.Login = funcionario.Login;
                    funcionarioEditado.Nome = funcionario.Nome;
                    funcionarioEditado.NumeroDeChapa = funcionario.NumeroDeChapa;
                    funcionarioEditado.Senha = funcionario.Senha;
                    funcionarioEditado.Sobrenome = funcionario.Sobrenome;
                    funcionarioEditado.Telefone1 = funcionario.Telefone1;
                    funcionarioEditado.Telefone2 = funcionario.Telefone2;
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
