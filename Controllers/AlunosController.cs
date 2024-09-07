using API_APSNET.DTO;
using API_APSNET.Models;
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

        [HttpGet("Alunos")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> BuscarTodasOsAlunos([FromQuery] Paginacao paginaParametros)
        {
            return await _AlunoService.BuscarTodasOsAlunos(paginaParametros);
        }

        [HttpGet("Alunos/{idProfessor}")]
        public async Task<ActionResult<ResponseModel<Models.Aluno>>> BuscarAlunoPorId(int id)
        {
            return await _AlunoService.BuscarAlunoPorId(id);
        }

        [HttpPost("CadastrarAluno")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> CadastrarAluno(AlunoDTO aluno)
        {
            return await _AlunoService.CadastrarAluno(aluno);
        }

        [HttpPut("AtualizarAluno")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> AtualizarAluno(AlunoDTO alunoEditado)
        {
            return await _AlunoService.AtualizarAluno(alunoEditado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> DeletarAluno(int id) {
            return await _AlunoService.DeletarAluno(id);
        }
    }
}
