using API_APSNET.DTO;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.AlunoDisciplina;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoDisciplinaController : ControllerBase
    {
        private readonly AlunoDisciplinaService _service;

        public AlunoDisciplinaController(AlunoDisciplinaService service)
        {
            _service = service;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<ResponseModel<Models.AlunoDisciplina>>> CadastrarAlunoNaDisciplina(AlunoDisciplinaDTO aluno)
        {
            return await _service.CadastrarAlunoNaDisciplina(aluno);
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseModel<Models.AlunoDisciplina>>> RemoverAlunoDaDisciplina(int alunoId, int disciplinaId)
        {
            return await _service.RemoverAlunoDaDisciplina(alunoId, disciplinaId);
        }
    }
}
