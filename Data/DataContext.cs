using Microsoft.EntityFrameworkCore;
using ProjetoEscola_API.Models;

namespace ProjetoEscola_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Professor> Professores { get; set; }
    }
}