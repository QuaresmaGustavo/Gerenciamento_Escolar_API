﻿using API_APSNET.DTO;
using API_APSNET.Models.Configuracao;
using API_APSNET.Service.Disciplina;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_APSNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly DisciplinaService _DisciplinaService;

        public DisciplinaController(DisciplinaService disciplinaService) {
            _DisciplinaService = disciplinaService;
        }

        [HttpGet("todos")]
        public async Task<ActionResult<ResponseModel<List<Models.Disciplina>>>> BuscarTodasAsDisciplinas([FromQuery] Paginacao paginaParametros)
        {
            return await _DisciplinaService.BuscarTodasAsDisciplinas(paginaParametros);
        }

        [HttpGet()]
        public async Task<ActionResult<ResponseModel<Models.Disciplina>>> BuscarDisciplinaPorNome(string nome)
        {
            return await _DisciplinaService.BuscarDisciplinaPorNome(nome);
        }

        [HttpGet("aluno")]
        public async Task<ActionResult<ResponseModel<List<Models.Aluno>>>> BuscarAlunoPelaDisciplina(int disciplinaID)
        {
            return await _DisciplinaService.BuscarAlunoPelaDisciplina(disciplinaID);
        }

        [HttpPost("GerarDisciplina")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<Models.Disciplina>>> GerarDisciplina(DisciplinaDTO disciplina)
        {
            return await _DisciplinaService.GerarDisciplina(disciplina);
        }

        [HttpPut("Atualizar")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<List<Models.Disciplina>>>> AtualizarDisciplina(DisciplinaDTO disciplinaEditada)
        {
            return await _DisciplinaService.AtualizarDisciplina(disciplinaEditada);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ResponseModel<List<Models.Disciplina>>>> DeletarDisciplina([FromQuery] int id)
        {
            return await _DisciplinaService.DeletarDisciplina(id);
        }
    }
}
