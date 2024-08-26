using API_APSNET.Models;

namespace API_APSNET.Service.Turma
{
    public interface ITurma
    {
        Task<ResponseModel<List<Models.Turma>>> BuscarTodasAsTurmas();
        Task<ResponseModel<Models.Turma>> BuscarTurmasPorId(int id);
        Task<ResponseModel<Models.Turma>> BuscarTurmasPorNome(string nome);
        Task<ResponseModel<List<Models.Turma>>> GerarTurmas(DTO.TurmaDTO turma);
        Task<ResponseModel<List<Models.Turma>>> AtualizarTurmas(DTO.TurmaDTO turma);
        Task<ResponseModel<List<Models.Turma>>> DeletarTurma(int id);
    }
}
