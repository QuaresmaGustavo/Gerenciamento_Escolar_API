using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Service.Turma;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurma _turmaInterface;
        private readonly TurmaService _turmaService;
        public TurmaController(ITurma turmaInterface) { _turmaInterface = turmaInterface; }

        [HttpGet("turmas")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> BuscarTodasAsTurmas()
        {
            return await _turmaInterface.BuscarTodasAsTurmas();
        }

        [HttpGet("turma/{idTurma}")]
        public async Task<ActionResult<ResponseModel<Turma>>> BuscarTodasAsTurmas(int idTurma)
        {
            return await _turmaInterface.BuscarTurmasPorId(idTurma);
        }

        [HttpPost("GerarTurma")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> GerarTurmas(TurmaDTO turma)
        {
            return await _turmaInterface.GerarTurmas(turma);
        }

        [HttpPut("AtualizarTurma")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> AtualizarTurmas(TurmaDTO turmaEditada)
        {
            return await _turmaInterface.AtualizarTurmas(turmaEditada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> DeletarTurma(int id)
        {
            return await _turmaInterface.DeletarTurma(id);
        }
    }
}
