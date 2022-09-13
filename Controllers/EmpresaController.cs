using System;
using ITERA.Interfaces.Services;
using ITERA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITERA.Controllers
{
    [ApiController]
    [Route("/empresa")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("{_id}")]
        public IActionResult Get(string _id)
        {
            try
            {
                var empresa = _empresaService.ObterPorId(_id);

                if (empresa == null)
                    return NotFound("Empresa não encontrada.");

                return Ok(empresa);
            }
            catch (Exception)
            {
                return Problem("Server Error");
            }
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
        public IActionResult Post(Empresa empresa)
        {
            try
            {
                var empresaExiste = _empresaService.ObterPorId(empresa.id);

                if (empresa.status != "ATIVO" && empresa.status != "INATIVO")
                    return BadRequest("O Status deve ser ATIVO ou INATIVO.");

                if (empresaExiste != null)
                    return BadRequest("Já existe uma Empresa com este Id.");

                _empresaService.Adicionar(empresa);

                return Ok(empresa);
            }
            catch (Exception)
            {
                return Problem("Server Error");
            }
        }

        [HttpPut("custos/{_id}")]
        [Authorize(Roles = "administrador")]
        public IActionResult Put(Empresa empresa)
        {
            // TODO: Implementar
            return Ok();
        }

        [HttpDelete("{_id}")]
        [Authorize(Roles = "administrador")]
        public IActionResult Delete(string _id)
        {
            try
            {
                var empresa = _empresaService.ObterPorId(_id);

                if (empresa == null)
                    return NotFound("Empresa não encontrada.");

                _empresaService.Remover(empresa);

                return Ok(empresa);
            }
            catch (Exception)
            {
                return Problem("Server Error");
            }
        }
    }
}