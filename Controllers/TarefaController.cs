using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Tarefa;
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
        public async Task<ActionResult<ResponseModel<List<Tarefa>>>> CadastrarTarefasNaDisciplina(int disciplinaId)
        {
            return await _service.BuscarTarefasDaDisciplina(disciplinaId);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<Tarefa>>> CadastrarTarefasNaDisciplina([FromBody] TarefaDTO dados, int disciplinaId){
            return await _service.CadastrarTarefasNaDisciplina(dados, disciplinaId);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseModel<Tarefa>>> AtualizarTarefa(int id,[FromBody] TarefaDTO dados){
            return await _service.AtualizarTarefa(id, dados);
        }

        [HttpDelete()]
        public async Task<ActionResult<ResponseModel<Tarefa>>> RemoverTarefa(int id){
            return await _service.RemoverTarefa(id);
        }
    }
}
