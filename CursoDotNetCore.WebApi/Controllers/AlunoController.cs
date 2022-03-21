using System.Collections.Generic;
using System.Linq;
using CursoDotNetCore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoDotNetCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            
            if(aluno == null){
                return BadRequest("Aluno não Encontrado");
            }else
                return Ok(aluno);
        }
    }
}