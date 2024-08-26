using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models;
using Microsoft.EntityFrameworkCore;

namespace API_APSNET.Service.Turma
{
    public class TurmaService : ITurma
    {
        private readonly AppDbContext _context;
        public TurmaService(AppDbContext context) { _context = context; }
        public async Task<ResponseModel<List<Models.Turma>>> AtualizarTurmas(TurmaDTO turmaEditada)
        {
            ResponseModel<List<Models.Turma>> resposta = new ResponseModel<List<Models.Turma>>();
            try
            {
                var turma = await _context.Turmas.FirstOrDefaultAsync(t => t.Id == turmaEditada.Id);

                if (turma != null) {
                    turma.Nome = turmaEditada.Nome;
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Turma Não encontrada!";
                }

                resposta.Dados = await _context.Turmas.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Turma>>> BuscarTodasAsTurmas()
        {
            ResponseModel<List<Models.Turma>> resposta = new ResponseModel<List<Models.Turma>>();
            try
            {
                var turmas = await _context.Turmas.ToListAsync();
                resposta.Dados = turmas;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Turma>> BuscarTurmasPorId(int id)
        {
            ResponseModel<Models.Turma> resposta = new ResponseModel<Models.Turma>();
            try
            {
                var turma = await _context.Turmas.FirstOrDefaultAsync(t => t.Id == id);
                resposta.Dados = turma;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Turma>> BuscarTurmasPorNome(string nome)
        {
            ResponseModel<Models.Turma> resposta = new ResponseModel<Models.Turma>();
            try
            {
                var turma = await _context.Turmas.FirstOrDefaultAsync(t => t.Nome == nome);
                resposta.Dados = turma;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Turma>>> DeletarTurma(int id)
        {
            ResponseModel<List<Models.Turma>> resposta = new ResponseModel<List<Models.Turma>>();
            try
            {
                var turma = await _context.Turmas.FirstOrDefaultAsync(t => t.Id == id);

                if (turma != null)
                {
                    _context.Turmas.Remove(turma);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Turma não encontrada!";
                }

                resposta.Dados = await _context.Turmas.ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Turma>>> GerarTurmas(DTO.TurmaDTO turma)
        {
            ResponseModel<List<Models.Turma>> resposta = new ResponseModel<List<Models.Turma>>();
            try
            {
                var novaTurma = new Models.Turma()
                {
                    Nome = turma.Nome
                };
                _context.Add(novaTurma);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Turmas.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }
    }
}
