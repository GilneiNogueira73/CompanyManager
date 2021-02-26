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
                    if (ValidaSeExisteNumeroChapa(funcionario))
                    {
                        return false;
                    }
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
                    if (funcionarioEditado is null)
                    {
                        return false;
                    }
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
                    funcionarioEditado.Excluido = funcionario.Excluido;
                    funcionarioEditado.LiderId = funcionario.LiderId;
                    if (ValidaSeExisteNumeroChapa(funcionarioEditado))
                    {
                        return false;
                    }
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        public bool ValidaSeExisteNumeroChapa(Funcionario funcionario)
        {
            using (var _context = new CompanyContext())
            {
                var existe = _context.Funcionarios.Find(funcionario.NumeroDeChapa);
                if (existe != null || existe.Id != funcionario.Id)
                {
                    return true;
                }

                return false;
            }
        }

        public bool ExcluirFuncionario(Funcionario funcionario)
        {
            if (funcionario.Id == null)
            {
                return false;
            }
            using (var _context = new CompanyContext())
            {
                try
                {
                    Funcionario funcionarioExcluido = _context.Funcionarios.Find(funcionario.Id);
                    if (funcionarioExcluido is null)
                    {
                        return false;
                    }
                    funcionarioExcluido.Excluido = true;
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        public bool DefineLider(Lider funcionarioLider)
        {
            if (funcionarioLider.FuncionarioId == null)
            {
                return false;
            }
            using (var _context = new CompanyContext())
            {
                try
                {
                    Funcionario funcionarioEditado = _context.Funcionarios.Find(funcionarioLider.FuncionarioId);
                    if (funcionarioEditado is null)
                    {
                        return false;
                    }
                    funcionarioLider.Excluido = funcionarioEditado.Excluido;
                    _context.Lideres.Add(funcionarioLider);
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
