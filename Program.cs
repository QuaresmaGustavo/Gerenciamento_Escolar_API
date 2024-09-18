using API_APSNET.Data;
using API_APSNET.Service.Aluno;
using API_APSNET.Service.AlunoDisciplina;
using API_APSNET.Service.Disciplina;
using API_APSNET.Service.Professor;
using API_APSNET.Service.Turma;
using Microsoft.EntityFrameworkCore;

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
