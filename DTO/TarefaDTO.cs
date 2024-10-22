using API_APSNET.Models;

namespace API_APSNET.DTO
{
    public class TarefaDTO
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public string? Descricao { get; set; }
        public int? PontuacaoMax { get; set; }
    }
}
