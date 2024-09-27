using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Service.Disciplina;
using Microsoft.EntityFrameworkCore;

namespace API_APSNET.Service.AlunoTarefaDisciplina
{
    public class AlunoTarefaDisciplinaService
    {
        private readonly AppDbContext _context;
        private readonly DisciplinaService disciplinaService;

        public AlunoTarefaDisciplinaService(AppDbContext context, DisciplinaService disciplinaService)
        {
            _context = context;
            this.disciplinaService = disciplinaService;
        }

        public async Task<ResponseModel<Models.AlunoTarefaDisciplina>> AdicionarRelacaoAlunoTarefaDisciplina(AlunoTarefaDisciplinaDTO dados){
            ResponseModel<Models.AlunoTarefaDisciplina> resposta = new ResponseModel<Models.AlunoTarefaDisciplina>();

            try{
                var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == dados.DisciplinaId);
                if (disciplina == null) { resposta.Mensagem = "Disciplina não encontrada!"; return resposta; }

                var alunos = await disciplinaService.BuscarAlunoPelaDisciplina(dados.DisciplinaId);
                if (alunos == null) { resposta.Mensagem = "Alunos não encontrados!"; return resposta; }

                foreach (var aluno in alunos.Dados){
                    var relacao = new Models.AlunoTarefaDisciplina(){
                        TarefaId = dados.TarefaId,
                        DisciplinaId = dados.DisciplinaId,
                        AlunoId = aluno.Id
                    };

                    _context.Add(relacao);
                }
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Tarefa enviada aos alunos!";
                return resposta;
            }
            catch (Exception ex){
                resposta.Mensagem = ex.InnerException.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.AlunoTarefaDisciplina>> RemoverTarefaDaDiscipina(int taredaId, int disciplinaId){
            ResponseModel<Models.AlunoTarefaDisciplina> resposta = new ResponseModel<Models.AlunoTarefaDisciplina>();
            try{
                var alunos = disciplinaService.BuscarAlunoPelaDisciplina(disciplinaId).Result.Dados;

                foreach (var aluno in alunos){
                    var alunoTarefaDisciplina = _context.AlunoTarefaDisciplinas
                                                        .FirstOrDefaultAsync(atd => atd.TarefaId == taredaId 
                                                                                    && atd.DisciplinaId == disciplinaId 
                                                                                    && atd.AlunoId == aluno.Id);

                    _context.Remove(alunoTarefaDisciplina);
                }

                await _context.SaveChangesAsync();

                resposta.Mensagem = "Tarefa removida com sucesso!";
                return resposta;
            }
            catch (Exception ex) { 
                resposta.Mensagem= ex.Message;
                return resposta;
            }
        }
    }
}
