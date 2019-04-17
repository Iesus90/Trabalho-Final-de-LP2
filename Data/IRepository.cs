using System.Threading.Tasks;
using ProjetoEscola_API.Models;

namespace ProjetoEscola_API.Data {
    public interface IRepository {
        //Geral
        void Add<T> (T entity) where T : class;
        void Update<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        Task<bool> SaveChangesAsync ();

        //ALUNO
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor);
        Task<Aluno> GetAlunosAsyncById(int AlunoId, bool includeProfessor);

        //PROFESSOR
        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);
        Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno);
        
    }
}