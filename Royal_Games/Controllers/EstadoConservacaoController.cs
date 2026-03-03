using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Applications.Services;
using Royal_Games.DTOs.EstadoConservacaoDto;
using Royal_Games.Exceptions;

namespace Royal_Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoConservacaoController : ControllerBase
    {
        private readonly EstadoConservacaoService _service;

        public EstadoConservacaoController(EstadoConservacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerEstadoConservacaoDto>> Listar()
        {
            List<LerEstadoConservacaoDto> estados = _service.Listar();
            return Ok(estados);
        }

        [HttpGet("{id}")]
        public ActionResult<LerEstadoConservacaoDto> ObterPorId(int id)
        {
            LerEstadoConservacaoDto estadoC = _service.ObterPorId(id);

            if (estadoC == null)
            {
                return NotFound();
            }

            return Ok(estadoC);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Adicionar(CriarEstadoConservacaoDto criarDto)
        {
            try
            {
                _service.Adicionar(criarDto);
                return StatusCode(201);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Atualizar(int id, CriarEstadoConservacaoDto criarDto)
        {
            try
            {
                _service.Atualizar(id, criarDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}