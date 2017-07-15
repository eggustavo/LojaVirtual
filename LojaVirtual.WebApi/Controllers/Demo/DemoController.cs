using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaVirtual.WebApi.Controllers.Demo
{
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("api/listar-nomes")]
        public IEnumerable<string> Listar()
        {
            return new string[]
            {
                "Adilson",
                "Ana",
                "Danilo",
                "Eduardo",
                "Francisco",
                "Maria Amália",
                "Odair",
                "Priscila"
            };
        }

        [HttpGet]
        [Route("api/listar-alunos")]
        public IEnumerable<Aluno> ListarAluno()
        {
            return new List<Aluno>()
            {
                new Aluno()
                {
                    Codigo = 1,
                    Nome = "Adilsn"
                },
                new Aluno()
                {
                    Codigo = 2,
                    Nome = "Ana"
                },
                new Aluno()
                {
                    Codigo = 3,
                    Nome = "Danilo"
                },
                new Aluno()
                {
                    Codigo = 4,
                    Nome = "Eduardo"
                },
                new Aluno()
                {
                    Codigo = 5,
                    Nome = "Francisco"
                },
                new Aluno()
                {
                    Codigo = 6,
                    Nome = "Maria Amália"
                },
                new Aluno()
                {
                    Codigo = 7,
                    Nome = "Odair"
                },
                new Aluno()
                {
                    Codigo = 8,
                    Nome = "Priscila"
                }
            };
        }
    }

    public class Aluno
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}