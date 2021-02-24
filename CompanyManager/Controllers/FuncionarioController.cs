using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyManager.Data;
using CompanyManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.Controllers
{
    [Route("funcionario")]
    [ApiController]
    public class FuncionarioController : Controller
    {
    [HttpGet]
    [Route("busca-funcionario/{id}")]
        public Funcionario GetFuncionariosById(string id)
        {
            return new FuncionarioRepository().GetFuncionariosById(Guid.Parse(id));
        }
    }
}