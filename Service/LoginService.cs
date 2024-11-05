using API_APSNET.Data;
using API_APSNET.Models.Configuracao;
using API_APSNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using API_APSNET.Enum;
using API_APSNET.DTO;

namespace API_APSNET.Service
{
    public class LoginService
    {
        private readonly AppDbContext _context;
        private readonly TokenService tokenService;

        public LoginService(AppDbContext appDbContext, TokenService tokenService) { 
            _context = appDbContext;
            this.tokenService = tokenService;
        }

        public async Task<ActionResult<ResponseModel<dynamic>>> Login(UsuarioDTO usuario)
        {
            ResponseModel<dynamic> resposta = new ResponseModel<dynamic>();

            try
            {
                switch (usuario.Cargo)
                {
                    case Cargo.Administrador:
                        var administrador = await _context.Administrador.FirstOrDefaultAsync(a => a.Login == usuario.Login);
                        if(administrador != null && VerificarSenha(administrador.Senha,usuario.Senha)) {
                            resposta.Mensagem = "Login ou senha invalido!";
                            return resposta;
                        }

                        var tokenAdmin = tokenService.tokenGeneration(administrador);

                        resposta.Dados = tokenAdmin.ToString();
                        break;
                    case Cargo.Aluno:
                        var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Login == usuario.Login);
                        if (aluno != null && VerificarSenha(aluno.Senha, usuario.Senha))
                        {
                            resposta.Mensagem = "Login ou senha invalido!";
                            return resposta;
                        }

                        var tokenAluno = tokenService.tokenGeneration(aluno);

                        resposta.Dados = tokenAluno.ToString();
                        break;
                    case Cargo.Professor:
                        var professor = await _context.Administrador.FirstOrDefaultAsync(a => a.Login == usuario.Login);
                        if (professor != null && VerificarSenha(professor.Senha, usuario.Senha))
                        {
                            resposta.Mensagem = "Login ou senha invalido!";
                            return resposta;
                        }

                        var tokenProfessor = tokenService.tokenGeneration(professor);

                        resposta.Dados = tokenProfessor.ToString();
                        break;
                }
                return resposta;
            }
            catch (Exception ex) { 
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        private bool VerificarSenha(string senhaBanco, string senhaUsuario)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes(senhaBanco));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senhaUsuario));
            return senhaBanco.Equals(computedHash);
        }
    }
}
