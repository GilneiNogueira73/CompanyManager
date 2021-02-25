using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyManager.Data;
using CompanyManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.Controllers
{
    [Route("Funcionario")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        [HttpGet]
        [Route("Listafuncionarios")]
        public IEnumerable<Funcionario> GetFuncionarios()
        {
            using (var _context = new CompanyContext())
            {
                return _context.Funcionarios.ToList();
            }

        }
        [HttpPost]
        [Route("IncluiFuncionario")]
        public ActionResult AddFuncionario(string nome, string login, string email, int numeroDeChapa, string senha, string sobrenome, int? telefone1, int? ddd1, int? telefone2, int? ddd2)
        {
            var id = Guid.NewGuid();
            Funcionario funcionario = new Funcionario();
            funcionario.Id = id;
            funcionario.Nome = nome;
            funcionario.Login = login;
            funcionario.Email = email;
            funcionario.NumeroDeChapa = numeroDeChapa;
            funcionario.Senha = senha;
            funcionario.Sobrenome = sobrenome;
            funcionario.Telefone1 = telefone1;
            funcionario.Ddd1 = ddd1;
            funcionario.Telefone2 = telefone2;
            funcionario.Ddd2 = ddd2;

            bool create = new FuncionarioRepository().CreateFuncionario(funcionario);

            if (create == true)
            {
                return Ok($"Funcionario {funcionario.Nome} cadastrado com sucesso!");
            }
            return Ok($"Não foi possível cadastrar o funcionario {funcionario.Nome}!");

        }

        [HttpPut]
        [Route("EditarFuncionario")]
        public ActionResult EditFuncionario(string id, string nome, string login, string email, int numeroDeChapa, string senha, string sobrenome, int? telefone1, int? ddd1, int? telefone2, int? ddd2)
        {
            var funcionarioId = id is null ? Guid.Empty : Guid.Parse(id);
            Funcionario funcionario = new Funcionario();
            funcionario.Id = funcionarioId;
            funcionario.Nome = nome;
            funcionario.Login = login;
            funcionario.Email = email;
            funcionario.NumeroDeChapa = numeroDeChapa;
            funcionario.Senha = senha;
            funcionario.Sobrenome = sobrenome;
            funcionario.Telefone1 = telefone1;
            funcionario.Ddd1 = ddd1;
            funcionario.Telefone2 = telefone2;
            funcionario.Ddd2 = ddd2;

            bool edit = new FuncionarioRepository().EditFuncionario(funcionario);

            if (edit == true)
            {
                return Ok($"Funcionario {funcionario.Nome} editado com sucesso!");
            }
            return Ok($"Não foi possível editar o funcionario {funcionario.Nome}!");

        }
    }
}