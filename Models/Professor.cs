using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class Professor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public DateTime Registro { get; set; }

        public int IdDisciplina { get; set; }

        [ForeignKey(nameof(IdDisciplina))]
        [JsonIgnore]
        public Disciplina Disciplina { get; set; }
    }
}
