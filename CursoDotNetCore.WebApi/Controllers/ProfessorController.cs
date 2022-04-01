using System.Linq;
using CursoDotNetCore.WebApi.Controllers.Data;
using CursoDotNetCore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoDotNetCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ProfessorController: ControllerBase
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);

            if (professor == null)
            {
                return BadRequest("Professor não Encontrado");
            }
            else
                return Ok(professor);
        }
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}}")]
        public IActionResult Put(int id, Professor professor)
        {
            var alu = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null)
                return BadRequest("Professor não encontrado");
            
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var alu = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null)
                return BadRequest("Professor não encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(prof == null)
                return BadRequest("Professor não encontrado");
            _context.Remove(prof);
            _context.SaveChanges();
            return Ok();
        }
    }
}