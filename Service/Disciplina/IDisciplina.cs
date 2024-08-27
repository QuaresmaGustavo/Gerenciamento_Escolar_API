using API_APSNET.Models;

namespace API_APSNET.Service.Disciplina
{
    public interface IDisciplina
    {
        Task<ResponseModel<List<Models.Disciplina>>> BuscarTodasAsDisciplinas();
        Task<ResponseModel<Models.Disciplina>> BuscarDisciplinaPorId(int id);
        Task<ResponseModel<Models.Disciplina>> BuscarDisciplinaPorNome(string nome);
        Task<ResponseModel<List<Models.Disciplina>>> GerarDisciplina(DTO.DisciplinaDTO disciplina);
        Task<ResponseModel<List<Models.Disciplina>>> AtualizarDisciplina(DTO.DisciplinaDTO disciplina);
        Task<ResponseModel<List<Models.Disciplina>>> DeletarDisciplina(int id);
    }
}
