﻿using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Models;
using Microsoft.EntityFrameworkCore;

namespace API_APSNET.Service.Aluno
{
    public class AlunoService
    {
        private readonly AppDbContext _context;
        public AlunoService(AppDbContext context) { _context = context; }
        public async Task<ResponseModel<List<Models.Aluno>>> AtualizarAluno(AlunoDTO alunoEditado)
        {
            ResponseModel<List<Models.Aluno>> resposta = new ResponseModel<List<Models.Aluno>>();
            try
            {
                var professor = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == alunoEditado.Id);

                if (professor != null){
                    if(professor.Nome != null){ professor.Nome = alunoEditado.Nome; }
                    if(professor.Idade != null){ professor.Idade = alunoEditado.Idade.Value; }
                }else{
                    resposta.Mensagem = "Turma não encontrada!";
                    return resposta;
                }

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

        public async Task<ResponseModel<List<Models.Aluno>>> BuscarTodasOsAlunos(Paginacao paginaParametros)
        {
            ResponseModel<List<Models.Aluno>> resposta = new ResponseModel<List<Models.Aluno>>();
            try
            {
                var aluno = await _context.Alunos.Skip(paginaParametros.Pagina).Take(paginaParametros.quantidade).ToListAsync();
                resposta.Dados = aluno;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Disciplina>>> BuscarDisciplinaPeloAluno(int alunoId)
        {
            ResponseModel<List<Models.Disciplina>> resposta = new ResponseModel<List<Models.Disciplina>>();
            try
            {
                var aluno = await _context.Alunos
                                    .Include(a => a.Disciplinas)
                                    .ThenInclude(ad => ad.Disciplina)
                                    .FirstOrDefaultAsync(a => a.Id == alunoId);

                if (aluno == null) {
                    resposta.Mensagem = "Aluno não encontrado";
                    return resposta;
                }

                var disciplina = aluno.Disciplinas.Select(ad => ad.Disciplina).ToList();

                resposta.Dados = disciplina;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Aluno>> CadastrarAluno(AlunoDTO aluno)
        {
            ResponseModel<Models.Aluno> resposta = new ResponseModel<Models.Aluno>();
            try
            {
                var verificarAluno = await BuscarAlunoPorNome(aluno.Nome);
                if (verificarAluno.Dados != null && verificarAluno.Dados.Nome.Equals(aluno.Nome)){
                    resposta.Mensagem = "Esta aluno ja existe!";
                    return resposta;
                }

                var novoAluno = new Models.Aluno(){
                    Nome = aluno.Nome,
                    Idade = aluno.Idade.Value,
                };
                _context.Add(novoAluno);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Alunos.OrderByDescending(a => a.Nome == aluno.Nome).FirstOrDefaultAsync();
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

                if (aluno != null){
                    _context.Alunos.Remove(aluno);
                    await _context.SaveChangesAsync();
                }else{
                    resposta.Mensagem = "Turma não encontrada!";
                    return resposta;
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
