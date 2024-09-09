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

        [HttpGet("todos")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> BuscarTodasAsTurmas([FromQuery] Paginacao paginacaoParametros)
        {
            return await _turmaService.BuscarTodasAsTurmas(paginacaoParametros);
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<ResponseModel<Turma>>> BuscarTurmasPorNome(string nome)
        {
            return await _turmaService.BuscarTurmasPorNome(nome);
        }

        [HttpPost("GerarTurma")]
        public async Task<ActionResult<ResponseModel<Turma>>> GerarTurmas(TurmaDTO turma)
        {
            return await _turmaService.GerarTurmas(turma);
        }

        [HttpPut("Atualizar")]
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
