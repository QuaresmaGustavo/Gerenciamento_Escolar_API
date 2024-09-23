using API_APSNET.Models;
using Microsoft.EntityFrameworkCore;

namespace API_APSNET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplina { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ManyToMany - Aluno/Disciplina
            modelBuilder.Entity<AlunoDisciplina>()
                .HasKey(ad => new { ad.IdAluno, ad.IdDisciplina });

            modelBuilder.Entity<AlunoDisciplina>()
                        .HasOne(ad => ad.Aluno)
                        .WithMany(a => a.Disciplinas)
                        .HasForeignKey(ad => ad.IdAluno);

            modelBuilder.Entity<AlunoDisciplina>()
                        .HasOne(ad => ad.Disciplina)
                        .WithMany(d => d.Alunos)
                        .HasForeignKey(ad => ad.IdDisciplina);
        }
    }
}
