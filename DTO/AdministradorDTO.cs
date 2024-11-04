using API_APSNET.Enum;

namespace API_APSNET.DTO
{
    public class AdministradorDTO
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Idade { get; set; }
        public DateOnly? Registro { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public Cargo? Cargo { get; set; }
    }
}
