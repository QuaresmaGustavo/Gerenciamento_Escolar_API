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
        private readonly IAluno _AlunoInterface;

        public AlunosController(IAluno alunoInterface){_AlunoInterface = alunoInterface;}

        [HttpGet("Alunos")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> BuscarTodasOsAlunos()
        {
            return await _AlunoInterface.BuscarTodasOsAlunos();
        }

        [HttpGet("Alunos/{idProfessor}")]
        public async Task<ActionResult<ResponseModel<Models.Aluno>>> BuscarAlunoPorId(int id)
        {
            return await _AlunoInterface.BuscarAlunoPorId(id);
        }

        [HttpPost("CadastrarAluno")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> CadastrarAluno(AlunoDTO aluno)
        {
            return await _AlunoInterface.CadastrarAluno(aluno);
        }

        [HttpPut("AtualizarAluno")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> AtualizarAluno(AlunoDTO alunoEditado)
        {
            return await _AlunoInterface.AtualizarAluno(alunoEditado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> DeletarAluno(int id) {
            return await _AlunoInterface.DeletarAluno(id);
        }
    }
}
