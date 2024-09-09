using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public List<Disciplina> disciplinas { get; set; }
    }
}
