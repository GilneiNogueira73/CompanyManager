using CompanyManager.Data;
using CompanyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManager.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        public readonly CompanyContext _companyContext;
        public FuncionarioService(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }
        public IQueryable<Funcionario> GetFuncionario(Guid id)
            => _companyContext.Funcionarios
                .Where(x => x.Id == id);
    }
}
