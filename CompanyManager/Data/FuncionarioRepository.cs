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
        private IEnumerable<Funcionario> Parser(DataTable dt)
        {
            var list = new List<Funcionario>();

            foreach (DataRow item in dt.Rows)
            {
                var funcionario = new Funcionario();
                funcionario.Id = Guid.Parse(item["Id"].ToString());
                funcionario.LiderId = Guid.Parse(item["LiderId"].ToString());
                funcionario.Login = item["Login"].ToString();
                funcionario.Nome = item["Nome"].ToString();
                funcionario.NumeroDeChapa = int.Parse(item["NumeroDeChapa"].ToString());
                funcionario.Senha = item["Senha"].ToString();
                funcionario.Sobrenome = item["Sobrenome"].ToString();
                funcionario.Telefone1 = int.Parse(item["Telefone1"].ToString());
                funcionario.Telefone2 = int.Parse(item["Telefone2"].ToString());
                funcionario.Ddd1 = int.Parse(item["Ddd1"].ToString());
                funcionario.Ddd2 = int.Parse(item["Ddd2"].ToString());
                funcionario.Email = item["Email"].ToString();

                list.Add(funcionario);
            }

            return list;
        }
        public Funcionario GetFuncionariosById(Guid id)
        {
            var conexaoBd = new BdConnection();
            conexaoBd.AddParameter("@id", id);

            var sql = @"SELECT  Id,
                                LiderId,
                                Login,
                                Nome,
                                NumeroDeChapa,
                                Senha,
                                Sobrenome,
                                Telefone1,
                                Telefone2,
                                Ddd1,
                                Ddd2,
                                Email

                       FROM     Funcionario
                       WHERE    Id = @id";

            var dt = conexaoBd.ExecuteReader(sql);

            return Parser(dt).FirstOrDefault();
        }
    }
}
