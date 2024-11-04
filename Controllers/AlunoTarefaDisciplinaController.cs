using API_APSNET.DTO;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.AlunoTarefaDisciplina;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoTarefaDisciplinaController : ControllerBase
    {
        private readonly AlunoTarefaDisciplinaService _service;

        public AlunoTarefaDisciplinaController(AlunoTarefaDisciplinaService service){
            _service = service;
        }

        [HttpPost]
        public async Task<ResponseModel<Models.AlunoTarefaDisciplina>> AdicionarRelacaoAlunoTarefaDisciplina(AlunoTarefaDisciplinaDTO dados) {
            return await _service.AdicionarRelacaoAlunoTarefaDisciplina(dados);
        }

        [HttpPut]
        public async Task<ResponseModel<Models.AlunoTarefaDisciplina>> AtualizarNotaTarefa(int idAluno, int idTarefa, AlunoTarefaDisciplinaDTO dados){
            return await _service.AtualizarNotaTarefa(idAluno, idTarefa, dados);
        }

        [HttpDelete]
        public async Task<ResponseModel<Models.AlunoTarefaDisciplina>> RemoverTarefaDaDiscipina(int tarefaId, int disciplinaId){
            return await _service.RemoverTarefaDaDiscipina(tarefaId, disciplinaId);
        }
    }
}
