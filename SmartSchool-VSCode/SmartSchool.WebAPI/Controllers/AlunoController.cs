using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {   
        public List<Aluno> alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Marta",
                Sobrenome = "Suplicir",
                Telefone = "123456"
            },
            new Aluno(){
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
        public AlunoController() { }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {   var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult getByNome(string nome, string sobrenome)
        {   var aluno = alunos.FirstOrDefault(a => a.Nome.Contains(nome));
            if(aluno == null) return BadRequest("Nome do aluno não se encontra em nossa base de dados.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //service.deleteById(id);
            return NoContent();
        }
    }
}