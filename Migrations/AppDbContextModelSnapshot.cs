﻿// <auto-generated />
using System;
using API_APSNET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_APSNET.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("API_APSNET.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("API_APSNET.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("IdAluno")
                        .HasColumnType("int");

                    b.Property<int>("IdDisciplina")
                        .HasColumnType("int");

                    b.HasKey("IdAluno", "IdDisciplina");

                    b.HasIndex("IdDisciplina");

                    b.ToTable("AlunoDisciplina");
                });

            modelBuilder.Entity("API_APSNET.Models.AlunoTarefaDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("TarefaId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int>("Pontuacao")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "TarefaId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("TarefaId");

                    b.ToTable("AlunoTarefaDisciplinas");
                });

            modelBuilder.Entity("API_APSNET.Models.Arquivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Conteudo")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TarefaId")
                        .HasColumnType("int");

                    b.Property<string>("TipoArquivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId")
                        .IsUnique();

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("API_APSNET.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("API_APSNET.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<string>("Formacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("Registro")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("API_APSNET.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PontuacaoMax")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("API_APSNET.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("API_APSNET.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("API_APSNET.Models.Aluno", "Aluno")
                        .WithMany("Disciplinas")
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_APSNET.Models.Disciplina", "Disciplina")
                        .WithMany("Alunos")
                        .HasForeignKey("IdDisciplina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("API_APSNET.Models.AlunoTarefaDisciplina", b =>
                {
                    b.HasOne("API_APSNET.Models.Aluno", "Aluno")
                        .WithMany("Tarefas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_APSNET.Models.Disciplina", "Disciplina")
                        .WithMany("Tarefas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_APSNET.Models.Tarefa", "Tarefa")
                        .WithMany("AlunoTarefaDisciplinas")
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("API_APSNET.Models.Arquivo", b =>
                {
                    b.HasOne("API_APSNET.Models.Tarefa", null)
                        .WithOne("arquivo")
                        .HasForeignKey("API_APSNET.Models.Arquivo", "TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_APSNET.Models.Disciplina", b =>
                {
                    b.HasOne("API_APSNET.Models.Turma", null)
                        .WithMany("disciplinas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_APSNET.Models.Professor", b =>
                {
                    b.HasOne("API_APSNET.Models.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("API_APSNET.Models.Aluno", b =>
                {
                    b.Navigation("Disciplinas");

                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("API_APSNET.Models.Disciplina", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("API_APSNET.Models.Tarefa", b =>
                {
                    b.Navigation("AlunoTarefaDisciplinas");

                    b.Navigation("arquivo")
                        .IsRequired();
                });

            modelBuilder.Entity("API_APSNET.Models.Turma", b =>
                {
                    b.Navigation("disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
