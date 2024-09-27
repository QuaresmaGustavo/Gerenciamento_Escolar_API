using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Formacao { get; set; }
        public int Idade { get; set; }
        public DateOnly Registro { get; set; }
        public int DisciplinaId { get; set; }
        [JsonIgnore]
        public Disciplina Disciplina { get; set; }
    }
}
