using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models;
using Microsoft.EntityFrameworkCore;

namespace API_APSNET.Service.Disciplina
{
    public class DisciplinaService
    {
        private readonly AppDbContext _context;
        public DisciplinaService(AppDbContext context){_context = context;}

        public async Task<ResponseModel<List<Models.Disciplina>>> AtualizarDisciplina(DisciplinaDTO disciplinaEditada)
        {
            ResponseModel<List<Models.Disciplina>> resposta = new ResponseModel<List<Models.Disciplina>>();
            try
            {
                var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == disciplinaEditada.Id);

                if (disciplina != null)
                {
                    disciplina.Nome = disciplinaEditada.Nome;
                    disciplina.Descricao = disciplinaEditada.Descricao;
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Turma Não encontrada!";
                }

                resposta.Dados = await _context.Disciplinas.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Disciplina>> BuscarDisciplinaPorId(int id)
        {
            ResponseModel<Models.Disciplina> resposta = new ResponseModel<Models.Disciplina>();
            try
            {
                var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == id);
                resposta.Dados = disciplina;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Disciplina>> BuscarDisciplinaPorNome(string nome)
        {
            ResponseModel<Models.Disciplina> resposta = new ResponseModel<Models.Disciplina>();
            try
            {
                var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Nome == nome);
                resposta.Dados = disciplina;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Disciplina>>> BuscarTodasAsDisciplinas(Paginacao paginaParametros)
        {
            ResponseModel<List<Models.Disciplina>> resposta = new ResponseModel<List<Models.Disciplina>>();
            try
            {
                var disciplina = await _context.Disciplinas.Skip(paginaParametros.Pagina).Take(paginaParametros.quantidade).ToListAsync();
                resposta.Dados = disciplina;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Disciplina>>> DeletarDisciplina(int id)
        {
            ResponseModel<List<Models.Disciplina>> resposta = new ResponseModel<List<Models.Disciplina>>();
            try
            {
                var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == id);

                if (disciplina != null)
                {
                    _context.Disciplinas.Remove(disciplina);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Turma não encontrada!";
                }

                resposta.Dados = await _context.Disciplinas.ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Disciplina>>> GerarDisciplina(DisciplinaDTO disciplina)
        {
            ResponseModel<List<Models.Disciplina>> resposta = new ResponseModel<List<Models.Disciplina>>();
            try
            {
                var novaDisciplina = new Models.Disciplina(){
                    Nome = disciplina.Nome,
                    Descricao = disciplina.Descricao
                };
                _context.Add(novaDisciplina);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Disciplinas.ToListAsync();
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
