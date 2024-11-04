using API_APSNET.Data;
using API_APSNET.DTO;
using API_APSNET.Enum;
using API_APSNET.Models.Configuracao;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API_APSNET.Service.Administrador
{
    public class AdministradorService
    {
        private readonly AppDbContext _context;
        public AdministradorService(AppDbContext context) { _context = context; }
        public async Task<ResponseModel<List<Models.Usuario>>> AtualizarAdmin(AdministradorDTO adminEditado)
        {
            ResponseModel<List<Models.Usuario>> resposta = new ResponseModel<List<Models.Usuario>>();
            try
            {
                var admin = await _context.Administrador.FirstOrDefaultAsync(a => a.Id == adminEditado.Id);

                if (admin != null)
                {
                    if (admin.Nome != null) { admin.Nome = adminEditado.Nome; }
                    if (admin.Idade != null) { admin.Idade = adminEditado.Idade; }
                }
                else
                {
                    resposta.Mensagem = "Turma não encontrada!";
                    return resposta;
                }

                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Administrador.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Usuario>> BuscarAdminPorNome(string nome)
        {
            ResponseModel<Models.Usuario> resposta = new ResponseModel<Models.Usuario>();
            try
            {
                var admin = await _context.Administrador.FirstOrDefaultAsync(a => a.Nome == nome);
                resposta.Dados = admin;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Usuario>>> BuscarTodasAdmins(Paginacao paginaParametros)
        {
            ResponseModel<List<Models.Usuario>> resposta = new ResponseModel<List<Models.Usuario>>();
            try
            {
                var admin = await _context.Administrador.Skip(paginaParametros.Pagina).Take(paginaParametros.quantidade).ToListAsync();
                resposta.Dados = admin;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<Models.Usuario>> CadastrarAdmin(AdministradorDTO admin)
        {
            ResponseModel<Models.Usuario> resposta = new ResponseModel<Models.Usuario>();
            try
            {
                var verificarAdmin = await BuscarAdminPorNome(admin.Nome);
                if (verificarAdmin.Dados != null && verificarAdmin.Dados.Nome.Equals(admin.Nome))
                {
                    resposta.Mensagem = "Esta admin ja existe!";
                    return resposta;
                }

                var hmac = new HMACSHA512();

                var novoAdmin = new Models.Usuario()
                {
                    Nome = admin.Nome,
                    Idade = admin.Idade,
                    Registro = DateOnly.FromDateTime(DateTime.Now),
                    Login = admin.Login,
                    Senha = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(admin.Senha))),
                    Cargo = (Cargo) admin.Cargo,
                };
                _context.Add(novoAdmin);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Alunos.OrderByDescending(a => a.Nome == admin.Nome).FirstOrDefaultAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Usuario>>> DeletarAdmin(int id)
        {
            ResponseModel<List<Models.Usuario>> resposta = new ResponseModel<List<Models.Usuario>>();
            try
            {
                var admin = await _context.Administrador.FirstOrDefaultAsync(a => a.Id == id);

                if (admin != null)
                {
                    _context.Administrador.Remove(admin);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resposta.Mensagem = "Admin não encontrada!";
                    return resposta;
                }

                resposta.Dados = await _context.Administrador.ToListAsync();
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
