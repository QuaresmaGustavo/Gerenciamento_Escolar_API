using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Turma;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> BuscarTodasAsTurmas([FromQuery] Paginacao paginacaoParametros)
        {
            return await _turmaService.BuscarTodasAsTurmas(paginacaoParametros);
        }

        [HttpGet("{nome}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<Turma>>> BuscarTurmasPorNome(string nome)
        {
            return await _turmaService.BuscarTurmasPorNome(nome);
        }

        [HttpPost("GerarTurma")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<Turma>>> GerarTurmas(TurmaDTO turma)
        {
            return await _turmaService.GerarTurmas(turma);
        }

        [HttpPut("Atualizar")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> AtualizarTurmas(TurmaDTO turmaEditada)
        {
            return await _turmaService.AtualizarTurmas(turmaEditada);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<List<Turma>>>> DeletarTurma([FromQuery] int id)
        {
            return await _turmaService.DeletarTurma(id);
        }
    }
}
