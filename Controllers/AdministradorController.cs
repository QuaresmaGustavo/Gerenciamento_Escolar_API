using API_APSNET.DTO;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Administrador;
using API_APSNET.Service.Aluno;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<List<Models.Administrador>>>> BuscarTodasAdmins([FromQuery] Paginacao paginaParametros)
        {
            return await _AdminService.BuscarTodasAdmins(paginaParametros);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<Models.Administrador>>> BuscarAdminPorNome([FromQuery] string nome)
        {
            return await _AdminService.BuscarAdminPorNome(nome);
        }

        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<Models.Administrador>>> CadastrarAdmin(AdministradorDTO aluno)
        {
            return await _AdminService.CadastrarAdmin(aluno);
        }

        [HttpPatch("Atualizar")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<List<Models.Administrador>>>> AtualizarAdmin(AdministradorDTO alunoEditado)
        {
            return await _AdminService.AtualizarAdmin(alunoEditado);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<List<Models.Administrador>>>> DeletarAdmin([FromQuery] int id)
        {
            return await _AdminService.DeletarAdmin(id);
        }
    }
}
