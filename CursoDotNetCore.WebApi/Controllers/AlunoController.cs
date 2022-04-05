using System.Collections.Generic;
using System.Linq;
using CursoDotNetCore.WebApi.Controllers.Data;
using CursoDotNetCore.WebApi.Data;
using CursoDotNetCore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoDotNetCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunosById(id, true);
            if (aluno == null)
            {
                return BadRequest("Aluno não Encontrado");
            }
            else
                return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if(_repo.SaveChanges())
                return Ok(aluno);
            else
                return BadRequest("Aluno não cadastrado");


        }

        [HttpPut("{id}}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunosById(id, true);
            if (alu == null)
                return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if(_repo.SaveChanges())
                return Ok(aluno);
            else
                return BadRequest("Aluno não atualizado");

        }

        [HttpPatch("{id}}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunosById(id, true);
            if (alu == null)
                return BadRequest("Aluno não encontrado");
            
            _repo.Update(aluno);
            if(_repo.SaveChanges())
                return Ok(aluno);
            else
                return BadRequest("Aluno não atualizado");
        }

        [HttpDelete("{id}}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunosById(id, true);
            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
            if(_repo.SaveChanges())
                return Ok(aluno);
            else
                return BadRequest("Aluno não Deletado");
        }
    }
}