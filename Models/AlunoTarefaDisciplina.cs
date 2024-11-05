using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class AlunoTarefaDisciplina{
        public int TarefaId { get; set; }
        [JsonIgnore]
        public Tarefa Tarefa { get; set; }
        public int DisciplinaId { get; set; }
        [JsonIgnore]
        public Disciplina Disciplina { get; set; }
        public int AlunoId { get; set; }
        [JsonIgnore]
        public Aluno Aluno { get; set; }
        public int Pontuacao { get; set; }
    }
}
