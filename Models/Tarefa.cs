using System.Text.Json.Serialization;

namespace API_APSNET.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int Pontuacao { get; set; }
        public int PontuacaoMax { get; set; }
        [JsonIgnore]
        public List<AlunoTarefaDisciplina> AlunoTarefaDisciplinas { get; set; }
    }
}
