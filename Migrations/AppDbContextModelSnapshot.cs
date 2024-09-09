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

                    b.Property<int>("IdDisciplina")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("IdDisciplina")
                        .IsUnique();

                    b.ToTable("Professores");
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

            modelBuilder.Entity("API_APSNET.Models.Disciplina", b =>
                {
                    b.HasOne("API_APSNET.Models.Turma", "Turma")
                        .WithMany("disciplinas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("API_APSNET.Models.Professor", b =>
                {
                    b.HasOne("API_APSNET.Models.Disciplina", "Disciplina")
                        .WithOne("Professor")
                        .HasForeignKey("API_APSNET.Models.Professor", "IdDisciplina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("API_APSNET.Models.Aluno", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("API_APSNET.Models.Disciplina", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Professor")
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
