namespace API_APSNET.DTO
{
    public class TarefaDTO
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public string? Descricao { get; set; }
        public int? Pontuacao { get; set; }
        public int? PontuacaoMax { get; set; }
        public int? DisciplinaId { get; set; }
    }
}
