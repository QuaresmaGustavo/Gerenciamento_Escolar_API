using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models;
using Microsoft.EntityFrameworkCore;

namespace API_APSNET.Service.AlunoDisciplina
{
    public class AlunoDisciplinaService
    {
        private readonly AppDbContext _Context;

        public AlunoDisciplinaService(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<ResponseModel<Models.AlunoDisciplina>> CadastrarAlunoNaDisciplina(AlunoDisciplinaDTO dados){

            ResponseModel<Models.AlunoDisciplina> resposta = new ResponseModel<Models.AlunoDisciplina>();

            try
            {
                var alunoDisciplina = new Models.AlunoDisciplina()
                {
                    IdAluno = dados.AlunoId,
                    IdDisciplina = dados.DisciplinaId
                };

                _Context.Add(alunoDisciplina);
                await _Context.SaveChangesAsync();

                resposta.Dados = alunoDisciplina;
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.AlunoDisciplina>>> RemoverAlunoDaDisciplina(int alunoId, int disciplinaId)
        {
            ResponseModel<List<Models.AlunoDisciplina>> resposta = new ResponseModel<List<Models.AlunoDisciplina>>();
            try
            {
                var aluno = await _Context.AlunoDisciplina.FirstOrDefaultAsync(ad => ad.IdAluno == alunoId && ad.IdDisciplina == disciplinaId);

                if (aluno != null)
                {
                    _Context.AlunoDisciplina.Remove(aluno);
                    await _Context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Aluno não encontrada!";
                }

                resposta.Dados = await _Context.AlunoDisciplina.ToListAsync();

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
