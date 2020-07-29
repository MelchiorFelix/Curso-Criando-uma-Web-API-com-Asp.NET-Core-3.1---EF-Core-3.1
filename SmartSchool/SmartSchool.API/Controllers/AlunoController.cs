using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Marta",
                Sobrenome = "Soares",
                Telefone = "123456"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "João",
                Sobrenome = "Carlos",
                Telefone = "654123"
            },
            new Aluno(){
                Id = 3,
                Nome = "Maria",
                Sobrenome = "das Dores",
                Telefone = "987456"
            },
        };
        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult get()
        {
            return Ok(alunos);
        }
        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
