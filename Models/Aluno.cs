using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class Aluno : Usuario
    {
        [JsonIgnore]
        public List<AlunoDisciplina> Disciplinas { get; set; }

        [JsonIgnore]
        public List<AlunoTarefaDisciplina> Tarefas { get; set; }
    }
}
