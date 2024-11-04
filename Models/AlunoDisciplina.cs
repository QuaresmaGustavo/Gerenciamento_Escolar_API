using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class AlunoDisciplina
    {
        public int IdAluno { get; set; }

        [JsonIgnore]
        public Administrador Aluno { get; set; }

        public int IdDisciplina { get; set; }

        [JsonIgnore]
        public Disciplina Disciplina { get; set; }
    }
}
