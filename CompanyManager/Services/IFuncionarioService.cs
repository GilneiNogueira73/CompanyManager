﻿using CompanyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManager.Services
{
    public interface IFuncionarioService
    {
        IQueryable<Funcionario> GetFuncionario(Guid id);
    }
}
