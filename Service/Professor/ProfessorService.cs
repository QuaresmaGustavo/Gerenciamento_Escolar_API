using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Enum;
using API_APSNET.Models.Configuracao;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API_APSNET.Service.Professor
{
    public class ProfessorService
    {
        private readonly AppDbContext _context;
        public ProfessorService(AppDbContext context) { _context = context; }

        public async Task<ResponseModel<List<Models.Professor>>> AtualizarProfessor(ProfessorDTO professorEditado)
        {
            ResponseModel<List<Models.Professor>> resposta = new ResponseModel<List<Models.Professor>>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Id == professorEditado.Id && p.Cargo == Cargo.Professor);

                if (professor != null){
                    if (professor.Nome != null){ professor.Nome = professorEditado.Nome;}
                    if (professor.Idade != null) { professor.Idade = professorEditado.Idade; }
                    if (professor.DisciplinaId != null) { professor.DisciplinaId = professorEditado.IdDisciplina; }
                }
                else{
                    resposta.Mensagem = "Professor não encontrado!";
                    return resposta;
                }

                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Professores.ToListAsync();
                return resposta;
            }
            catch (Exception ex){
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Professor>> BuscarProfessorPorNome(string nome)
        {
            ResponseModel<Models.Professor> resposta = new ResponseModel<Models.Professor>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Nome == nome && p.Cargo == Cargo.Professor);
                resposta.Dados = professor;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Professor>>> BuscarTodasOsProfessores(Paginacao paginaParametros)
        {
            ResponseModel<List<Models.Professor>> resposta = new ResponseModel<List<Models.Professor>>();
            try
            {
                var professor = await _context.Professores.Skip(paginaParametros.Pagina).Take(paginaParametros.quantidade).ToListAsync();
                resposta.Dados = professor;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

         public async Task<ResponseModel<Models.Professor>> CadastrarProfessor(ProfessorDTO professor)
        {
            ResponseModel<Models.Professor> resposta = new ResponseModel<Models.Professor>();
            try
            {
                var verificarprofessor = await BuscarProfessorPorNome(professor.Nome);
                if (verificarprofessor.Dados != null && verificarprofessor.Dados.Nome.Equals(professor.Nome))
                {
                    resposta.Mensagem = "Este professor já existe";
                    return resposta;
                }

                var hmac = new HMACSHA512();

                var novoProfessor = new Models.Professor()
                {
                    Nome = professor.Nome,
                    Idade = professor.Idade,
                    DisciplinaId = professor.IdDisciplina,
                    Registro = DateOnly.FromDateTime(DateTime.Now),
                    Login = professor.Login,
                    Senha = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(professor.Senha))),
                    Cargo = (Cargo) professor.Cargo,
                };
                _context.Add(novoProfessor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Professores.OrderByDescending(p => p.Nome == professor.Nome).FirstOrDefaultAsync();
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
                    return resposta;
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
