using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_APSNET.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaAlunoTarefaDisciplina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Alunos_AlunoId",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Disciplinas_DisciplinaId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_AlunoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_DisciplinaId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdDisciplina",
                table: "Professores");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Registro",
                table: "Professores",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.CreateTable(
                name: "AlunoTarefaDisciplinas",
                columns: table => new
                {
                    TarefaId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTarefaDisciplinas", x => new { x.AlunoId, x.TarefaId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoTarefaDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTarefaDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTarefaDisciplinas_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTarefaDisciplinas_DisciplinaId",
                table: "AlunoTarefaDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTarefaDisciplinas_TarefaId",
                table: "AlunoTarefaDisciplinas",
                column: "TarefaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTarefaDisciplinas");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Registro",
                table: "Professores",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "IdDisciplina",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_AlunoId",
                table: "Tarefas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_DisciplinaId",
                table: "Tarefas",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Alunos_AlunoId",
                table: "Tarefas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Disciplinas_DisciplinaId",
                table: "Tarefas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
