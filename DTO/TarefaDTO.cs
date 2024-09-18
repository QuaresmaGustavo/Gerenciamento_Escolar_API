namespace API_APSNET.DTO
{
    public class TarefaDTO
    {
        public int? id {  get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int pontuacao { get; set; }
        public int DisciplinaId { get; set; }
    }
}
