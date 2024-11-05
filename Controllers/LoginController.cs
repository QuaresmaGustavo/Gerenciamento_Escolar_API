using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService) { _loginService = loginService; }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<dynamic>>> Login([FromBody] UsuarioDTO usuario) {
                return await _loginService.Login(usuario);
        } 
    }
}
