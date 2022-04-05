using System.Linq;
using CursoDotNetCore.WebApi.Controllers.Data;
using CursoDotNetCore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoDotNetCore.WebApi.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Aluno[] GetAllAlunos(bool includeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeDisciplina){
                query.Include(ad => ad.AlunosDisciplina).
                ThenInclude(d => d.Disciplina).
                ThenInclude(p => p.Professor);
            }
            

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeDisciplina){
                query.Include(ad => ad.AlunosDisciplina).
                ThenInclude(d => d.Disciplina).
                ThenInclude(p => p.Professor);
            }
            

            query = query.AsNoTracking().
                OrderBy(a => a.Id).
                Where(x => x.AlunosDisciplina.Any( y => y.DisciplinaId == disciplinaId));
            return query.ToArray();
        }

        public Professor[] GetAllProfessores(bool includeDisciplina = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeDisciplina){
                query.Include(ad => ad.Disciplinas).
                ThenInclude(d => d.AlunosDisciplinas).
                ThenInclude(p => p.Aluno);
            }
            

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeDisciplina = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeDisciplina){
                query.Include(ad => ad.Disciplinas).
                ThenInclude(d => d.AlunosDisciplinas).
                ThenInclude(p => p.Aluno);
            }
            

            query = query.AsNoTracking().
                OrderBy(a => a.Id).
                Where(aluno => aluno.Disciplinas.Any(
                    d => d.AlunosDisciplinas.Any(
                        ad => ad.DisciplinaId == disciplinaId
                    )
                ));

            return query.ToArray();
        }

        public Aluno GetAlunosById(int alunoId, bool includeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeDisciplina){
                query.Include(ad => ad.AlunosDisciplina).
                ThenInclude(d => d.Disciplina).
                ThenInclude(p => p.Professor);
            }
            

            query = query.AsNoTracking().
                OrderBy(a => a.Id).
                Where(x => x.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Professor GetProfessoresById(int professorId, bool includeDisciplina = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeDisciplina){
                query.Include(ad => ad.Disciplinas).
                ThenInclude(d => d.AlunosDisciplinas).
                ThenInclude(p => p.Aluno);
            }
            

            query = query.AsNoTracking().
                OrderBy(a => a.Id).
                Where(x => x.Id == professorId);

            return query.FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}