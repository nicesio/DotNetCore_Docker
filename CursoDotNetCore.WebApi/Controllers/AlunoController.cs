using System.Collections.Generic;
using System.Linq;
using CursoDotNetCore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoDotNetCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController: ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "João",
                SobreNome = "Nunes",
                Telefone = "63254632"
            }, 
            new Aluno(){
                Id = 2,
                Nome = "Marta",
                SobreNome = "Nunes",
                Telefone = "63254632"
            }, 
            new Aluno(){
                Id = 3,
                Nome = "Nunes",
                SobreNome = "Nunes",
                Telefone = "63254632"
            }, 
        };
        public AlunoController()
        {
            
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            
            if(aluno == null){
                return BadRequest("Aluno não Encontrado");
            }else
                return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}