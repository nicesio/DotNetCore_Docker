using System.Linq;
using CursoDotNetCore.WebApi.Controllers.Data;
using CursoDotNetCore.WebApi.Data;
using CursoDotNetCore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoDotNetCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ProfessorController: ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessoresById(id, true);

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
            _repo.Add(professor);
            if(_repo.SaveChanges())
                return Ok(professor);
            else
                return BadRequest("Aluno não cadastrado");


        }

        [HttpPut("{id}}")]
        public IActionResult Put(int id, Professor professor)
        {
            var alu = _repo.GetProfessoresById(id, true);
            if(alu == null)
                return BadRequest("Professor não encontrado");
            
            _repo.Update(professor);
            if(_repo.SaveChanges())
                return Ok(professor);
            else
                return BadRequest("Aluno não cadastrado");

        }

        [HttpPatch("{id}}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var alu = _repo.GetProfessoresById(id, true);
            if(alu == null)
                return BadRequest("Professor não encontrado");
            
            _repo.Update(professor);
            if(_repo.SaveChanges())
                return Ok(professor);
            else
                return BadRequest("Aluno não cadastrado");

        }

        [HttpDelete("{id}}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessoresById(id, true);
            if(prof == null)
                return BadRequest("Professor não encontrado");
            
            _repo.Delete(prof);
            if(_repo.SaveChanges())
                return Ok(prof);
            else
                return BadRequest("Aluno não cadastrado");

        }
    }
}