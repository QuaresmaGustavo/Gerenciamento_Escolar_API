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

        public async Task<ResponseModel<Models.AlunoDisciplina>> CadastrarAlunoNaDisciplina(AlunoDisciplinaDTO dados)
        {
            ResponseModel<Models.AlunoDisciplina> resposta = new ResponseModel<Models.AlunoDisciplina>();

            try
            {
                var alunoDiscilpina = new Models.AlunoDisciplina()
                {
                    IdAluno = dados.AlunoId,
                    IdDisciplina = dados.DisciplinaId
                };

                _Context.Add(alunoDiscilpina);
                await _Context.SaveChangesAsync();

                resposta.Dados = alunoDiscilpina;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.AlunoDisciplina>> RemoverAlunoDaDisciplina(int alunoId, int disciplinaId)
        {
            ResponseModel<Models.AlunoDisciplina> resposta = new ResponseModel<Models.AlunoDisciplina>();

            try
            {
                var aluno = await _Context.AlunoDisciplina.FirstOrDefaultAsync(ad => ad.IdAluno == alunoId && ad.IdDisciplina == disciplinaId);

                if (aluno == null)
                {
                    resposta.Mensagem = "Aluno não encontrado";
                    return resposta;
                }

                _Context.Remove(aluno);
                await _Context.SaveChangesAsync();

                resposta.Mensagem = "Aluno removido com sucesso!";
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
