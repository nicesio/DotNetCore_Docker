using CursoDotNetCore.WebApi.Models;

namespace CursoDotNetCore.WebApi.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         bool SaveChanges();
         Aluno [] GetAllAlunos(bool includeDisciplina = false);
         Aluno [] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeDisciplina = false);
         Aluno GetAlunosById(int alunoId, bool includeDisciplina = false);

         Professor [] GetAllProfessores(bool includeDisciplina = false);
         Professor [] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeDisciplina = false);
         Professor GetProfessoresById(int professorId, bool includeDisciplina = false);
    }
}