using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class Aluno
    {
        public int Id {get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        [JsonIgnore]
        public List<AlunoDisciplina> Disciplinas { get; set; }

        [JsonIgnore]
        public List<AlunoTarefaDisciplina> Tarefas { get; set; }
    }
}
