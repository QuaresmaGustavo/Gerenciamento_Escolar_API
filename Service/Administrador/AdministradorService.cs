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
        public async Task<ResponseModel<List<Models.Administrador>>> AtualizarAdmin(AdministradorDTO adminEditado)
        {
            ResponseModel<List<Models.Administrador>> resposta = new ResponseModel<List<Models.Administrador>>();
            try
            {
                var admin = await _context.Administrador.FirstOrDefaultAsync(a => a.Id == adminEditado.Id);

                if (admin != null)
                {
                    if (admin.Nome != null) { admin.Nome = adminEditado.Nome; }
                    if (admin.Idade != null) { admin.Idade = adminEditado.Idade; }
                    if (admin.Login != null) { admin.Login = adminEditado.Login; }
                    if (admin.Senha != null) { admin.Senha = adminEditado.Senha; }
                }
                else
                {
                    resposta.Mensagem = "administrador não encontrada!";
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

        public async Task<ResponseModel<Models.Administrador>> BuscarAdminPorNome(string nome)
        {
            ResponseModel<Models.Administrador> resposta = new ResponseModel<Models.Administrador>();
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

        public async Task<ResponseModel<List<Models.Administrador>>> BuscarTodasAdmins(Paginacao paginaParametros)
        {
            ResponseModel<List<Models.Administrador>> resposta = new ResponseModel<List<Models.Administrador>>();
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

        public async Task<ResponseModel<Models.Administrador>> CadastrarAdmin(AdministradorDTO admin)
        {
            ResponseModel<Models.Administrador> resposta = new ResponseModel<Models.Administrador>();
            try
            {
                var verificarAdmin = await BuscarAdminPorNome(admin.Nome);
                if (verificarAdmin.Dados != null && verificarAdmin.Dados.Nome.Equals(admin.Nome))
                {
                    resposta.Mensagem = "Esta administrador ja existe!";
                    return resposta;
                }

                var hmac = new HMACSHA512();

                var novoAdmin = new Models.Administrador()
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

                resposta.Dados = await _context.Administrador.OrderByDescending(a => a.Nome == admin.Nome).FirstOrDefaultAsync();
                resposta.Mensagem = "Administrador cadastrado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Models.Administrador>>> DeletarAdmin(int id)
        {
            ResponseModel<List<Models.Administrador>> resposta = new ResponseModel<List<Models.Administrador>>();
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
                    resposta.Mensagem = "Administrador não encontrada!";
                    return resposta;
                }

                resposta.Mensagem = "Administrador deletado com sucesso!";
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
