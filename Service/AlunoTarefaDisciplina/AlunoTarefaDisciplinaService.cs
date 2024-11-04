using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Disciplina;
using Microsoft.AspNetCore.Mvc;
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

                var alunos = await disciplinaService.BuscarAlunoPelaDisciplina(dados.DisciplinaId.Value);
                if (alunos == null) { resposta.Mensagem = "Alunos não encontrados!"; return resposta; }

                foreach (var aluno in alunos.Dados){
                    var relacao = new Models.AlunoTarefaDisciplina(){
                        TarefaId = dados.TarefaId.Value,
                        DisciplinaId = dados.DisciplinaId.Value,
                        AlunoId = aluno.Id,
                        Pontuacao = 0
                    };

                    _context.Add(relacao);
                }
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Tarefa enviada aos alunos!";
                return resposta;
            }
            catch (Exception ex){
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.AlunoTarefaDisciplina>> AtualizarNotaTarefa(int idAluno, int idTarefa, AlunoTarefaDisciplinaDTO dados)
        {
            ResponseModel<Models.AlunoTarefaDisciplina> resposta = new ResponseModel<Models.AlunoTarefaDisciplina>();
            try
            {
                var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == idTarefa);
                var aluno = _context.AlunoTarefaDisciplinas.FirstOrDefault(t => t.AlunoId == idAluno && t.TarefaId == idTarefa);

                if (tarefa == null || aluno == null){
                    resposta.Mensagem = "Erro ao alterar nota!";
                    return resposta;
                }

                if (dados.Pontuacao != null && dados.Pontuacao <= tarefa.PontuacaoMax) {
                    aluno.Pontuacao = dados.Pontuacao.Value;
                }else {
                    resposta.Mensagem = "Nota do aluno não pode ser maior que a nota maxima da atividade";
                    return resposta;
                }

                await _context.SaveChangesAsync();
                resposta.Mensagem = "nota atualizado";
                return resposta;

            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
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
