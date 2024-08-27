using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Service.Disciplina;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplina _DisciplinaInterface;

        public DisciplinaController(IDisciplina disciplinaInterface)
        {
            _DisciplinaInterface = disciplinaInterface;
        }

        [HttpGet("Disciplinas")]
        public async Task<ActionResult<ResponseModel<List<Models.Disciplina>>>> BuscarTodasAsDisciplinas()
        {
            return await _DisciplinaInterface.BuscarTodasAsDisciplinas();
        }

        [HttpGet("Disciplinas/{idDisciplina}")]
        public async Task<ActionResult<ResponseModel<Models.Disciplina>>> BuscarTodasAsDisciplinas(int idDisciplina)
        {
            return await _DisciplinaInterface.BuscarDisciplinaPorId(idDisciplina);
        }

        [HttpPost("GerarDisciplina")]
        public async Task<ActionResult<ResponseModel<List<Models.Disciplina>>>> GerarDisciplina(DisciplinaDTO disciplina)
        {
            return await _DisciplinaInterface.GerarDisciplina(disciplina);
        }

        [HttpPut("AtualizarDisciplina")]
        public async Task<ActionResult<ResponseModel<List<Models.Disciplina>>>> AtualizarDisciplina(DisciplinaDTO disciplinaEditada)
        {
            return await _DisciplinaInterface.AtualizarDisciplina(disciplinaEditada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<List<Models.Disciplina>>>> DeletarDisciplina(int id)
        {
            return await _DisciplinaInterface.DeletarDisciplina(id);
        }
    }
}
