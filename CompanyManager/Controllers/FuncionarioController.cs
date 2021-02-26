using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyManager.Data;
using CompanyManager.Models;
using CompanyManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.Controllers
{
    [Authorize]
    [Route("Funcionario")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        private CompanyContext db = new CompanyContext();
        public ActionResult Index()
        {
            return View(db.Funcionarios.ToList());
        }
        [HttpGet]
        [Route("Listafuncionarios")]
        public IEnumerable<Funcionario> GetFuncionarios()
        {
            using (var _context = new CompanyContext())
            {
                return _context.Funcionarios.ToList();
            }

        }
        [Route("Id")]
        public IEnumerable<Funcionario> GetFuncionariosById(Guid id)
        {
            using (var _context = new CompanyContext())
            {
                return _context.Funcionarios
                .Where(x => x.Id == id).ToList(); 
            }

        }
        [HttpPost]
        [Route("IncluiFuncionario")]
        public ActionResult AddFuncionario(string nome, string login, string email, int numeroDeChapa, string senha, string sobrenome, Guid liderId, int? telefone1, int? ddd1, int? telefone2, int? ddd2)
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
            funcionario.LiderId = liderId;
            funcionario.Telefone1 = telefone1;
            funcionario.Ddd1 = ddd1;
            funcionario.Telefone2 = telefone2;
            funcionario.Ddd2 = ddd2;
            funcionario.Excluido = false;

            if (funcionario.LiderId.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                funcionario.LiderId = null;
            }
            bool create = new FuncionarioRepository().CreateFuncionario(funcionario);

            if (create == true)
            {
                return Ok($"Funcionario {funcionario.Nome} cadastrado com sucesso!");
            }
            return Ok($"Não foi possível cadastrar o funcionario {funcionario.Nome}!");
        }
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.Id = Guid.NewGuid();
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [Route("DefinirLider")]
        public ActionResult DefineLider(Guid funcionarioId)
        {
            Lider funcionarioLider = new Lider();
            var id = Guid.NewGuid();
            funcionarioLider.Id = id;
            funcionarioLider.FuncionarioId = funcionarioId;

            bool create = new FuncionarioRepository().DefineLider(funcionarioLider);

            if (create == true)
            {
                return Ok($"Lider cadastrado com sucesso!");
            }
            return Ok($"Não foi possível cadastrar o líder!");
        }


        [HttpPut]
        [Route("EditarFuncionario")]
        public ActionResult EditFuncionario(string id, string nome, string login, string email, int numeroDeChapa, string senha, string sobrenome, Guid liderId, int? telefone1, int? ddd1, int? telefone2, int? ddd2, bool excluido)
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
            funcionario.LiderId = liderId;
            funcionario.Telefone1 = telefone1;
            funcionario.Ddd1 = ddd1;
            funcionario.Telefone2 = telefone2;
            funcionario.Ddd2 = ddd2;
            funcionario.Excluido = excluido;

            if (funcionario.LiderId.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                funcionario.LiderId = null;
            }

            bool edit = new FuncionarioRepository().EditFuncionario(funcionario);

            if (edit == true)
            {
                return Ok($"Funcionario {funcionario.Nome} editado com sucesso!");
            }
            return Ok($"Não foi possível editar o funcionario {funcionario.Nome}!");
        }

        [Route("ExcluirFuncionario")]
        public ActionResult ExcluirFuncionario(string id)
        {
            var funcionarioId = id is null ? Guid.Empty : Guid.Parse(id);
            Funcionario funcionario = new Funcionario();
            funcionario.Id = funcionarioId;

            bool edit = new FuncionarioRepository().ExcluirFuncionario(funcionario);

            if (edit == true)
            {
                return Ok($"Funcionario {funcionario.Nome} excluído com sucesso!");
            }
            return Ok($"Não foi possível excluir o funcionario {funcionario.Nome}!");

        }




        
    }
}