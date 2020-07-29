using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult put(int id, Professor professor)
        {
            var p = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (p == null) return BadRequest("Professor não encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var p = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (p == null) return BadRequest("Professor não encontrado");
            _context.Remove(p);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
