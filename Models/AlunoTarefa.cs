namespace API_APSNET.Models
{
    public class AlunoTarefa
    {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}
