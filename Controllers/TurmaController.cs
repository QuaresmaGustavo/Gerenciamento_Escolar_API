using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Service.Turma;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly TurmaService _turmaService;
        public TurmaController(TurmaService turmaService) { _turmaService = turmaService; }

        [HttpGet("turmas")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> BuscarTodasAsTurmas([FromQuery] Paginacao paginacaoParametros)
        {
            return await _turmaService.BuscarTodasAsTurmas(paginacaoParametros);
        }

        [HttpGet("turmas/{idTurma}")]
        public async Task<ActionResult<ResponseModel<Turma>>> BuscarTurmasPorId(int idTurma)
        {
            return await _turmaService.BuscarTurmasPorId(idTurma);
        }

        [HttpPost("GerarTurma")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> GerarTurmas(TurmaDTO turma)
        {
            return await _turmaService.GerarTurmas(turma);
        }

        [HttpPut("AtualizarTurma")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> AtualizarTurmas(TurmaDTO turmaEditada)
        {
            return await _turmaService.AtualizarTurmas(turmaEditada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> DeletarTurma(int id)
        {
            return await _turmaService.DeletarTurma(id);
        }
    }
}
