using System.Collections.Generic;

namespace ProjetoEscola_API.Models
{
    public class Professor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string DataNasc { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}