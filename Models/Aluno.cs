namespace API_APSNET.Models
{
    public class Aluno
    {
        public int Id {get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public Disciplina Disciplina { get; set; }
    }
}
