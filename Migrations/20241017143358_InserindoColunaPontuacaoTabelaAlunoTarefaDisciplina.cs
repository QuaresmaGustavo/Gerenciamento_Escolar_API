using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_APSNET.Migrations
{
    /// <inheritdoc />
    public partial class InserindoColunaPontuacaoTabelaAlunoTarefaDisciplina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pontuacao",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "Pontuacao",
                table: "AlunoTarefaDisciplinas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pontuacao",
                table: "AlunoTarefaDisciplinas");

            migrationBuilder.AddColumn<int>(
                name: "Pontuacao",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
