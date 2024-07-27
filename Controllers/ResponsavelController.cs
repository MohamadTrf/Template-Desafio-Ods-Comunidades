using Microsoft.AspNetCore.Mvc;
using Template_Desafio_Ods_Comunidades.Models;
using Template_Desafio_Ods_Comunidades.Service;

namespace Template_Desafio_Ods_Comunidades.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponsavelController : ControllerBase
    {
        private readonly ResponsavelService _responsavelService;

        public ResponsavelController(ResponsavelService responsavelService)
        {
            _responsavelService = responsavelService;
        }

        [HttpPost("CadastrarResponsavel")]
        public async Task<ActionResult<Indicador>> CadastrarResponsavel(Responsavel responsavel)
        {
             await _responsavelService.CadastrarResponsavel(responsavel);
            return StatusCode(201);
        }
        
        [HttpPut("AtualizarResponsavel/{email}")]
        public async Task<IActionResult> AtualizarResponsavel(Responsavel responsavelAtualizado,String email)
        {
            var atualizado = await _responsavelService.AtualizarResponsavel(responsavelAtualizado,email);
      
            return Ok();
        }
    }
}
