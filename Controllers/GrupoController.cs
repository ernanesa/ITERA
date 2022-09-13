using System;
using System.Linq;
using System.Text.RegularExpressions;
using ITERA.Interfaces.Services;
using ITERA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITERA.Controllers
{
    [ApiController]
    [Route("/grupo")]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoService _grupoService;
        private readonly IEmpresaService _empresaService;


        public GrupoController(IGrupoService grupoService, IEmpresaService empresaService)
        {
            _grupoService = grupoService;
            _empresaService = empresaService;
        }

        [HttpGet]
        public IActionResult Get(string date)
        {
            try
            {
                var regex = new Regex(@"\d{4}-\d{2}-\d{2}");
                if (!regex.IsMatch(date.ToString()))
                    return BadRequest("Date Format: YYYY-MM-DD");

                var newDate = DateTime.Parse(date);
                var grupos = _grupoService.ObterPorData(newDate).ToList();

                if (grupos.Count == 0)
                    return NotFound("Empresa não encontrada.");

                return Ok(grupos);
            }
            catch (Exception)
            {
                return Problem("Server Error");
            }
        }

        [HttpGet("{_id}")]
        public IActionResult Get(int _id)
        {
            try
            {
                var grupo = _grupoService.ObterPorId(_id);

                if (grupo == null)
                    return NotFound("Grupo não encontrado.");

                return Ok(grupo);
            }
            catch (Exception)
            {
                return Problem("Server Error");
            }
        }

        [HttpGet("custos/{_id}")]
        public IActionResult Get(Grupo grupo)
        {
            return Ok();
        }

        [HttpPut("{_id}")]
        [Authorize(Roles = "administrador")]
        public IActionResult Put([FromRoute] int _id, [FromQuery] string id_empresa)
        {
            var grupo = _grupoService.ObterPorId(_id);
            var empresa = _empresaService.ObterPorId(id_empresa);

            if (grupo == null || empresa == null)
                return BadRequest("Grupo ou Empresa não encontrado.");

            _grupoService.Atualizar(grupo, empresa);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
        public IActionResult Post(Grupo grupo)
        {
            try
            {
                var grupoExiste = _grupoService.ObterPorId(grupo.id);

                if (grupoExiste != null)
                    return BadRequest("Já existe um Grupo com este Id.");

                _grupoService.Adicionar(grupo);

                return Ok(grupo);
            }
            catch (Exception)
            {
                return Problem("Server Error");
            }
        }
    }
}