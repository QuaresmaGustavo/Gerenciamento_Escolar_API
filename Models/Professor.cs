using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class Professor : Usuario
    {
        public int DisciplinaId { get; set; }
        [JsonIgnore]
        public Disciplina Disciplina { get; set; }
    }
}
