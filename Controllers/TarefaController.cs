using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Tarefa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaService _service;

        public TarefaController(TarefaService service){
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<Tarefa>>>> BuscarTarefasDaDisciplina(int disciplinaId)
        {
            return await _service.BuscarTarefasDaDisciplina(disciplinaId);
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<ActionResult<ResponseModel<Tarefa>>> CadastrarTarefasNaDisciplina([FromBody] TarefaDTO dados, int disciplinaId){
            return await _service.CadastrarTarefasNaDisciplina(dados, disciplinaId);
        }

        [HttpPatch]
        [Authorize(Roles = "Professor")]
        public async Task<ActionResult<ResponseModel<Tarefa>>> AtualizarTarefa([FromQuery] int id,[FromBody] TarefaDTO dados){
            return await _service.AtualizarTarefa(id, dados);
        }

        [HttpDelete]
        [Authorize(Roles = "Professor")]
        public async Task<ActionResult<ResponseModel<Tarefa>>> RemoverTarefa([FromQuery] int id){
            return await _service.RemoverTarefa(id);
        }
    }
}
