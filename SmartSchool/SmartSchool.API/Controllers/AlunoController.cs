using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;
        public AlunoController(DataContext context)
        {
            _context = context;
        }
        
       

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.Alunos);
        }


        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }


        [HttpGet("byName")]
        public IActionResult getByNome(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)); 
            if (aluno == null) return BadRequest("Nome do aluno não se encontra em nossa base de dados.");
            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var a = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (a == null) return BadRequest("Aluno não encontrado");
            _context.Update(a);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var a = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (a == null) return BadRequest("Aluno não encontrado");
            _context.Update(a);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var a = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (a == null) return BadRequest("Aluno não encontrado");
            _context.Remove(a);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
