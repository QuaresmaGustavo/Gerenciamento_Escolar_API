using API_APSNET.DTO;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Professor;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorService _ProfessorService;

        public ProfessorController(ProfessorService professorService)
        {
            _ProfessorService = professorService;
        }

        [HttpGet("todos")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> BuscarTodasOsProfessores([FromQuery] Paginacao paginaParametros)
        {
            return await _ProfessorService.BuscarTodasOsProfessores(paginaParametros);
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<ResponseModel<Models.Professor>>> BuscarProfessorPorNome(string nome)
        {
            return await _ProfessorService.BuscarProfessorPorNome(nome);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<ResponseModel<Models.Professor>>> CadastrarProfessor([FromBody] ProfessorDTO professor)
        {
            return await _ProfessorService.CadastrarProfessor(professor);
        }

        [HttpPatch("atualizar")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> AtualizarProfessor([FromBody] ProfessorDTO professorEditado)
        {
            return await _ProfessorService.AtualizarProfessor(professorEditado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> DeletarProfessor(int id)
        {
            return await _ProfessorService.DeletarProfessor(id);
        }
    }
}
