using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models;
using API_APSNET.Service.Disciplina;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_APSNET.Service.Tarefa
{
    public class TarefaService
    {
        private readonly AppDbContext _Context;
        private readonly DisciplinaService disciplinaService;

        public TarefaService(AppDbContext context, DisciplinaService disciplinaService){
            _Context = context;
            this.disciplinaService = disciplinaService;
        }

        public async Task<ResponseModel<List<Models.Tarefa>>> BuscarTarefasDaDisciplina(int disciplinaId)
        {
            ResponseModel<List<Models.Tarefa>> resposta = new ResponseModel<List<Models.Tarefa>>();
            try
            {
                var disciplina = await _Context.Disciplinas.FirstOrDefaultAsync(d => d.Id == disciplinaId);

                if (disciplina == null) {
                    resposta.Mensagem = "Disciplina Procurada não encontrada";
                    return resposta;
                }

                var tarefas = await _Context.AlunoTarefaDisciplinas.Where(atd => atd.DisciplinaId == disciplinaId).Select(atd => atd.Tarefa).Distinct().ToListAsync();

                if (tarefas == null){
                    resposta.Mensagem = "Nenhuma tarefa encontrada para esta disciplina";
                    return resposta;
                }

                resposta.Dados = tarefas;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Tarefa>> CadastrarTarefasNaDisciplina(TarefaDTO dados, int disciplinaId){
            ResponseModel<Models.Tarefa> resposta = new ResponseModel<Models.Tarefa>();
            try {
                int pontuacaoMax = 0;

                var tarefas = await _Context.AlunoTarefaDisciplinas.Where(atd => atd.DisciplinaId == disciplinaId).Select(atd => atd.Tarefa).Distinct().ToListAsync();

                foreach (var t in tarefas){
                    pontuacaoMax += t.PontuacaoMax;
                }

                if (dados.PontuacaoMax + pontuacaoMax > 100){
                    resposta.Mensagem = "O somatorio das pontuações não pode ser maior que 100 pontos";
                    return resposta;
                }

                var novaTarefa = new Models.Tarefa(){
                    Nome = dados.Nome,
                    Tipo = dados.Tipo,
                    Descricao = dados.Descricao,
                    Pontuacao = dados.Pontuacao.Value,
                    PontuacaoMax = dados.PontuacaoMax.Value
                };

                _Context.Add(novaTarefa);
                await _Context.SaveChangesAsync();

                resposta.Mensagem = "Tarefa cadastrada com sucesso";
                return resposta;

            } catch (Exception e) { 
                resposta.Mensagem = e.Message;
                return resposta;
            }
        }

        public async Task<ActionResult<ResponseModel<Models.Tarefa>>> AtualizarTarefa(int id, TarefaDTO dados){
            ResponseModel<Models.Tarefa> resposta = new ResponseModel<Models.Tarefa>();
            try {

                var tarefa = _Context.Tarefas.FirstOrDefault(t => t.Id == id);

                if(tarefa == null){
                    resposta.Mensagem = "Esta tarefa não existe!";
                    return resposta;
                }

                if (dados.Pontuacao != null) {tarefa.Pontuacao = dados.Pontuacao.Value;}
                if (dados.Nome != null) { tarefa.Nome = dados.Nome; }
                if (dados.Tipo != null) { tarefa.Tipo = dados.Tipo; }
                if (dados.Descricao != null) { tarefa.Descricao = dados.Descricao; }
                if (dados.PontuacaoMax != null) { tarefa.PontuacaoMax = dados.PontuacaoMax.Value; }

                await _Context.SaveChangesAsync();
                resposta.Mensagem = "Campo atualizado";
                return resposta;

            } catch (Exception e) { 
                resposta.Mensagem=e.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Tarefa>> RemoverTarefa(int id)
        {
            ResponseModel<Models.Tarefa> resposta = new ResponseModel<Models.Tarefa>();

            try{
                var tarefa = await _Context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);

                if (tarefa == null){
                    resposta.Mensagem = "Tarefa não encontrado";
                    return resposta;
                }

                _Context.Remove(tarefa);
                await _Context.SaveChangesAsync();

                resposta.Mensagem = "Tarefa removido com sucesso!";
                return resposta;
            }
            catch (Exception ex){
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }
    }
}
