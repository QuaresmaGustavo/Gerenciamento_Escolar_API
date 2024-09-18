using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Service.AlunoDisciplina;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoDisciplinaController : ControllerBase
    {
        private readonly AlunoDisciplinaService _AlunoDisciplinaService;

        public AlunoDisciplinaController(AlunoDisciplinaService alunoDisciplinaService)
        {
            _AlunoDisciplinaService = alunoDisciplinaService;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<ResponseModel<Models.AlunoDisciplina>>> CadastrarAluno(AlunoDisciplinaDTO alunoDisciplina)
        {
            return await _AlunoDisciplinaService.CadastrarAlunoNaDisciplina(alunoDisciplina);
        }

        [HttpDelete]
        public async Task<ResponseModel<List<Models.AlunoDisciplina>>> RemoverAlunoDaDisciplina(int alunoId, int disciplinaId)
        {
            return await _AlunoDisciplinaService.RemoverAlunoDaDisciplina(alunoId, disciplinaId);
        }
    }
}
