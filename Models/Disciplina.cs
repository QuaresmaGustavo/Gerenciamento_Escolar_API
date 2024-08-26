using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Turma Turma { get; set; }

        [JsonIgnore]
        public Professor Professor { get; set; }
        
        [JsonIgnore]
        public List<Aluno> Alunos { get; set; }
    }
}
