namespace API_APSNET.Models.Configuracao
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; }
    }
}
