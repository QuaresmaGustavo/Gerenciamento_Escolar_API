using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models;
using Microsoft.EntityFrameworkCore;

namespace API_APSNET.Service.Professor
{
    public class ProfessorService : IProfessor
    {
        private readonly AppDbContext _context;
        public ProfessorService(AppDbContext context) { _context = context; }

        public async Task<ResponseModel<List<Models.Professor>>> AtualizarProfessor(ProfessorDTO professorEditado)
        {
            ResponseModel<List<Models.Professor>> resposta = new ResponseModel<List<Models.Professor>>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Id == professorEditado.Id);

                if (professor != null)
                {
                    professor.Nome = professorEditado.Nome;
                    professor.Idade = professorEditado.Idade;
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Turma Não encontrada!";
                }

                resposta.Dados = await _context.Professores.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Professor>> BuscarProfessorPorId(int id)
        {
            ResponseModel<Models.Professor> resposta = new ResponseModel<Models.Professor>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Id == id);
                resposta.Dados = professor;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Professor>> BuscarProfessorPorNome(string nome)
        {
            ResponseModel<Models.Professor> resposta = new ResponseModel<Models.Professor>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Nome == nome);
                resposta.Dados = professor;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Professor>>> BuscarTodasOsProfessores()
        {
            ResponseModel<List<Models.Professor>> resposta = new ResponseModel<List<Models.Professor>>();
            try
            {
                var professor = await _context.Professores.ToListAsync();
                resposta.Dados = professor;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Professor>>> CadastrarProfessor(ProfessorDTO professor)
        {
            ResponseModel<List<Models.Professor>> resposta = new ResponseModel<List<Models.Professor>>();
            try
            {
                var novoProfessor = new Models.Professor(){
                    Nome = professor.Nome,
                    Idade = professor.Idade
                };
                _context.Add(novoProfessor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Professores.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Professor>>> DeletarProfessor(int id)
        {
            ResponseModel<List<Models.Professor>> resposta = new ResponseModel<List<Models.Professor>>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(d => d.Id == id);

                if (professor != null)
                {
                    _context.Professores.Remove(professor);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Turma não encontrada!";
                }

                resposta.Dados = await _context.Professores.ToListAsync();

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
