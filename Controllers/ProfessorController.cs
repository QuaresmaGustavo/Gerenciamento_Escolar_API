using API_APSNET.DTO;
using API_APSNET.Models;
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

        [HttpGet("Professores")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> BuscarTodasOsProfessores([FromQuery] Paginacao paginaParametros)
        {
            return await _ProfessorService.BuscarTodasOsProfessores(paginaParametros);
        }

        [HttpGet("Professores/{idProfessor}")]
        public async Task<ActionResult<ResponseModel<Models.Professor>>> BuscarProfessorPorId(int id)
        {
            return await _ProfessorService.BuscarProfessorPorId(id);
        }

        [HttpPost("CadastrarProfessor")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> CadastrarProfessor(ProfessorDTO professor)
        {
            return await _ProfessorService.CadastrarProfessor(professor);
        }

        [HttpPut("AtualizarProfessor")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> AtualizarProfessor(ProfessorDTO professorEditado)
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
