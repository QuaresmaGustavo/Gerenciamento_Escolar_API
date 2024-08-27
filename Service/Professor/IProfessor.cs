using API_APSNET.Models;

namespace API_APSNET.Service.Professor
{
    public interface IProfessor
    {
        Task<ResponseModel<List<Models.Professor>>> BuscarTodasOsProfessores();
        Task<ResponseModel<Models.Professor>> BuscarProfessorPorId(int id);
        Task<ResponseModel<Models.Professor>> BuscarProfessorPorNome(string nome);
        Task<ResponseModel<List<Models.Professor>>> CadastrarProfessor(DTO.ProfessorDTO professor);
        Task<ResponseModel<List<Models.Professor>>> AtualizarProfessor(DTO.ProfessorDTO professor);
        Task<ResponseModel<List<Models.Professor>>> DeletarProfessor(int id);
    }
}
