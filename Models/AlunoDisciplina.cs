using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class AlunoDisciplina
    {
        public int IdAluno { get; set; }

        [JsonIgnore]
        public Aluno Aluno { get; set; }

        public int IdDisciplina { get; set; }

        [JsonIgnore]
        public Disciplina Disciplina { get; set; }
    }
}
