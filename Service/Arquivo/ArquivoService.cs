using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models.Configuracao;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Service.Arquivo
{
    public class ArquivoService : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArquivoService(AppDbContext context) {
            _context = context;
        }

        public async Task<ResponseModel<Models.Arquivo>> BuscarArquivo(int id){
            ResponseModel<Models.Arquivo> resposta = new ResponseModel<Models.Arquivo>();

            try {
                var arquivo = await _context.Arquivos.FindAsync(id);

                if (arquivo == null)
                {
                    resposta.Mensagem = "Arquivo não encontrado!";
                    return resposta;
                }

                resposta.Dados = arquivo;
                return resposta;

            }
            catch (Exception ex) { 
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<IActionResult> BaixarArquivo(int id)
        {
            ResponseModel<Models.Arquivo> resposta = new ResponseModel<Models.Arquivo>();

            try
            {
                var documento = await _context.Arquivos.FindAsync(id);

                if (documento == null)
                {
                    return NotFound("Documento não encontrado.");
                }

                var memory = new MemoryStream(documento.Conteudo);
                memory.Position = 0;

                return File(memory, documento.TipoArquivo, documento.Nome);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        public async Task<ResponseModel<Models.Arquivo>> CarregarArquivo(ArquivoDTO arquivo){
            ResponseModel<Models.Arquivo> resposta = new ResponseModel<Models.Arquivo>();

            try {
                if (arquivo.Arquivo == null || arquivo.Arquivo.Length == 0 ) {
                    resposta.Mensagem = "Erro ao baixar o arquivo";
                    return resposta;
                }

                using (var memoryStream = new MemoryStream()){
                    await arquivo.Arquivo.CopyToAsync(memoryStream);
                    var arquivoBaixado = new Models.Arquivo
                    {
                        Nome = arquivo.Arquivo.FileName,
                        TipoArquivo = arquivo.Arquivo.ContentType,
                        Conteudo = memoryStream.ToArray(),
                        TarefaId = arquivo.TarefaId,
                    };

                    _context.Arquivos.Add(arquivoBaixado);
                    await _context.SaveChangesAsync();
                }

                resposta.Mensagem = "Arquivo baixado com sucesso!";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Arquivo>> DeletarArquivo(int id){
            ResponseModel<Models.Arquivo> resposta = new ResponseModel<Models.Arquivo>();

            try {
                var arquivo = _context.Arquivos.FirstOrDefault(x => x.Id == id);
                if (arquivo == null)
                {
                    resposta.Mensagem = "Arquivo não encontrado!";
                    return resposta;
                }

                _context.Remove(arquivo);
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Arquivo Removido com sucesso!";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }
    }
}
