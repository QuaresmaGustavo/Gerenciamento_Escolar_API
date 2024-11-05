using API_APSNET.Data;
using API_APSNET.Service;
using API_APSNET.Service.Administrador;
using API_APSNET.Service.Aluno;
using API_APSNET.Service.AlunoDisciplina;
using API_APSNET.Service.AlunoTarefaDisciplina;
using API_APSNET.Service.Arquivo;
using API_APSNET.Service.Disciplina;
using API_APSNET.Service.Professor;
using API_APSNET.Service.Tarefa;
using API_APSNET.Service.Turma;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 21))));


builder.Services.AddScoped<AlunoService>();
builder.Services.AddScoped<DisciplinaService>();
builder.Services.AddScoped<ProfessorService>();
builder.Services.AddScoped<TurmaService>();
builder.Services.AddScoped<AlunoDisciplinaService>();
builder.Services.AddScoped<TarefaService>();
builder.Services.AddScoped<AlunoTarefaDisciplinaService>();
builder.Services.AddScoped<ArquivoService>();
builder.Services.AddScoped<AdministradorService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<TokenService>();


var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
