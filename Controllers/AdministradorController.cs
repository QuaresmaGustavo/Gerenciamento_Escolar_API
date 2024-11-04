using API_APSNET.DTO;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Administrador;
using API_APSNET.Service.Aluno;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly AdministradorService _AdminService;

        public AdministradorController(AdministradorService adminInterface) { _AdminService = adminInterface; }

        [HttpGet("todos")]
        public async Task<ActionResult<ResponseModel<List<Models.Usuario>>>> BuscarTodasAdmins([FromQuery] Paginacao paginaParametros)
        {
            return await _AdminService.BuscarTodasAdmins(paginaParametros);
        }

        [HttpGet()]
        public async Task<ActionResult<ResponseModel<Models.Usuario>>> BuscarAdminPorNome(string nome)
        {
            return await _AdminService.BuscarAdminPorNome(nome);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<ResponseModel<Models.Usuario>>> CadastrarAdmin(AdministradorDTO aluno)
        {
            return await _AdminService.CadastrarAdmin(aluno);
        }

        [HttpPatch("Atualizar")]
        public async Task<ActionResult<ResponseModel<List<Models.Usuario>>>> AtualizarAdmin(AdministradorDTO alunoEditado)
        {
            return await _AdminService.AtualizarAdmin(alunoEditado);
        }

        [HttpDelete()]
        public async Task<ActionResult<ResponseModel<List<Models.Usuario>>>> DeletarAdmin([FromQuery] int id)
        {
            return await _AdminService.DeletarAdmin(id);
        }
    }
}
