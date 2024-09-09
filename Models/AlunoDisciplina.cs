namespace API_APSNET.Models
{
    public class AlunoDisciplina
    {
        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }
        public int IdDisciplina { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
