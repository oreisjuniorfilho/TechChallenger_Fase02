using BlogNoticias.Api.Data.Auth;
using BlogNoticias.Api.Data.Dto;
using BlogNoticias.Api.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogNoticias.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoticiasController : ControllerBase
    {
        private readonly INoticiaRepository _noticiaRepository;
      
        public NoticiasController(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        [HttpGet("Consultar")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> ListarNoticias()
        {
            List<ReadNoticiaDto> readDto = await _noticiaRepository.ObterNoticias();
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPost("Cadastrar")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CadastrarNoticia(CreateNoticiaDto noticia)
        {
            ReadNoticiaDto readDto = await _noticiaRepository.CadastrarNoticia(noticia);
            return CreatedAtAction(nameof(RecuperaNoticiaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("Consultar/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RecuperaNoticiaPorId(int id)
        {
            ReadNoticiaDto readDto = await _noticiaRepository.ObterNoticiasPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }
    }
}
