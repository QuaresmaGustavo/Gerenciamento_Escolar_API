using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models;
using Microsoft.EntityFrameworkCore;

namespace API_APSNET.Service.Aluno
{
    public class AlunoService : IAluno
    {
        private readonly AppDbContext _context;
        public AlunoService(AppDbContext context) { _context = context; }
        public async Task<ResponseModel<List<Models.Aluno>>> AtualizarAluno(AlunoDTO alunoEditado)
        {
            ResponseModel<List<Models.Aluno>> resposta = new ResponseModel<List<Models.Aluno>>();
            try
            {
                var professor = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == alunoEditado.Id);

                if (professor != null)
                {
                    professor.Nome = alunoEditado.Nome;
                    professor.Idade = alunoEditado.Idade;
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Turma Não encontrada!";
                }

                resposta.Dados = await _context.Alunos.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Aluno>> BuscarAlunoPorId(int id)
        {
            ResponseModel<Models.Aluno> resposta = new ResponseModel<Models.Aluno>();
            try
            {
                var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);
                resposta.Dados = aluno;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Aluno>> BuscarAlunoPorNome(string nome)
        {
            ResponseModel<Models.Aluno> resposta = new ResponseModel<Models.Aluno>();
            try
            {
                var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Nome == nome);
                resposta.Dados = aluno;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Aluno>>> BuscarTodasOsAlunos()
        {
            ResponseModel<List<Models.Aluno>> resposta = new ResponseModel<List<Models.Aluno>>();
            try
            {
                var aluno = await _context.Alunos.ToListAsync();
                resposta.Dados = aluno;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Aluno>>> CadastrarAluno(AlunoDTO aluno)
        {
            ResponseModel<List<Models.Aluno>> resposta = new ResponseModel<List<Models.Aluno>>();
            try
            {
                var novoAluno = new Models.Aluno()
                {
                    Nome = aluno.Nome,
                    Idade = aluno.Idade
                };
                _context.Add(novoAluno);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Alunos.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Aluno>>> DeletarAluno(int id)
        {
            ResponseModel<List<Models.Aluno>> resposta = new ResponseModel<List<Models.Aluno>>();
            try
            {
                var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

                if (aluno != null)
                {
                    _context.Alunos.Remove(aluno);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Turma não encontrada!";
                }

                resposta.Dados = await _context.Alunos.ToListAsync();

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
