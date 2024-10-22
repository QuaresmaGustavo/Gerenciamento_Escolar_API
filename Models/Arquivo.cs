namespace API_APSNET.Models
{
    public class Arquivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoArquivo { get; set; }
        public byte[] Conteudo { get; set; }
        public int TarefaId { get; set; }
    }
}
