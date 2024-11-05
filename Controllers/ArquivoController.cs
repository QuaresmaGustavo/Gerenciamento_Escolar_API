using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Arquivo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly ArquivoService _service;

        public ArquivoController(ArquivoService service) { _service = service; }

        [HttpGet]
        public async Task<ResponseModel<Arquivo>> BuscarArquivo([FromQuery] int id){
            return await _service.BuscarArquivo(id);
        }

        [HttpGet("/download")]
        public async Task<IActionResult> BaixarArquivo([FromQuery] int id)
        {
            return await _service.BaixarArquivo(id);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Professor")]
        public async Task<ResponseModel<Arquivo>> CarregarArquivo([FromForm] ArquivoDTO arquivo)
        {
            return await _service.CarregarArquivo(arquivo);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador, Professor")]
        public async Task<ResponseModel<Arquivo>> DeletarArquivo([FromQuery] int id)
        {
            return await _service.DeletarArquivo(id);
        }
    }
}
