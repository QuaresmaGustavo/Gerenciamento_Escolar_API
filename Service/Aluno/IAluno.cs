using API_APSNET.Models;

namespace API_APSNET.Service.Aluno
{
    public interface IAluno
    {
        Task<ResponseModel<List<Models.Aluno>>> BuscarTodasOsAlunos();
        Task<ResponseModel<Models.Aluno>> BuscarAlunoPorId(int id);
        Task<ResponseModel<Models.Aluno>> BuscarAlunoPorNome(string nome);
        Task<ResponseModel<List<Models.Aluno>>> CadastrarAluno(DTO.AlunoDTO aluno);
        Task<ResponseModel<List<Models.Aluno>>> AtualizarAluno(DTO.AlunoDTO aluno);
        Task<ResponseModel<List<Models.Aluno>>> DeletarAluno(int id);
    }
}
