using API_APSNET.DTO;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Aluno;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AlunoService _AlunoService;

        public AlunosController(AlunoService alunoInterface){ _AlunoService = alunoInterface;}

        [HttpGet("todos")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> BuscarTodasOsAlunos([FromQuery] Paginacao paginaParametros){
            return await _AlunoService.BuscarTodasOsAlunos(paginaParametros);
        }

        [HttpGet()]
        public async Task<ActionResult<ResponseModel<Models.Aluno>>> BuscarAlunoPorNome(string nome){
            return await _AlunoService.BuscarAlunoPorNome(nome);
        }

        [HttpGet("disciplina")]
        public async Task<ActionResult<ResponseModel<List<Models.Disciplina>>>> BuscarDisciplinasPorIDAluno(int alunoId){
            return await _AlunoService.BuscarDisciplinaPeloAluno(alunoId);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<ResponseModel<Models.Aluno>>> CadastrarAluno(AlunoDTO aluno){
            return await _AlunoService.CadastrarAluno(aluno);
        }

        [HttpPatch("Atualizar")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> AtualizarAluno(AlunoDTO alunoEditado){
            return await _AlunoService.AtualizarAluno(alunoEditado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> DeletarAluno(int id) {
            return await _AlunoService.DeletarAluno(id);
        }
    }
}
