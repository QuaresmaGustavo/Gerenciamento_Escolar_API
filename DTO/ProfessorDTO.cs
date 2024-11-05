using API_APSNET.Enum;
using System.Security.Cryptography;

namespace API_APSNET.DTO
{
    public class ProfessorDTO
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Idade { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public Cargo? Cargo { get; set; }
        public int IdDisciplina { get; set; }
    }
}
