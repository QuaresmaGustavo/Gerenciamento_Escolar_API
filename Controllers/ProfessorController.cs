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
        private readonly IProfessor _ProfessorInterface;

        public ProfessorController(IProfessor professorInterface)
        {
            _ProfessorInterface = professorInterface;
        }

        [HttpGet("Professores")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> BuscarTodasOsProfessores()
        {
            return await _ProfessorInterface.BuscarTodasOsProfessores();
        }

        [HttpGet("Professores/{idProfessor}")]
        public async Task<ActionResult<ResponseModel<Models.Professor>>> BuscarProfessorPorId(int id)
        {
            return await _ProfessorInterface.BuscarProfessorPorId(id);
        }

        [HttpPost("CadastrarProfessor")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> CadastrarProfessor(ProfessorDTO professor)
        {
            return await _ProfessorInterface.CadastrarProfessor(professor);
        }

        [HttpPut("AtualizarProfessor")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> AtualizarProfessor(ProfessorDTO professorEditado)
        {
            return await _ProfessorInterface.AtualizarProfessor(professorEditado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<List<Models.Professor>>>> DeletarProfessor(int id)
        {
            return await _ProfessorInterface.DeletarProfessor(id);
        }
    }
}
