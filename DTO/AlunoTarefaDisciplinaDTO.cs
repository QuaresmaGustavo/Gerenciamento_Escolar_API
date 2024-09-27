using API_APSNET.Models;
using System.Text.Json.Serialization;

namespace API_APSNET.DTO
{
    public class AlunoTarefaDisciplinaDTO{
        public int TarefaId { get; set; }

        public int DisciplinaId { get; set; }
    }
}
