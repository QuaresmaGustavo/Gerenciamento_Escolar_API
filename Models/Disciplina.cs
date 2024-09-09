using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int TurmaID { get; set; }

        [JsonIgnore]
        public List<AlunoDisciplina> Alunos { get; set; }
    }
}
