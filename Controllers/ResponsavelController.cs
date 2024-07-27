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
<<<<<<< HEAD

        [HttpPut("Desativar/{email}")]
        public async Task<IActionResult> DesativarResponsavel(String email, Boolean Ativo)
        {
            var result = await _responsavelService.DesativarResponsavel(email, Ativo);

=======
        
        [HttpPut("AtualizarResponsavel/{email}")]
        public async Task<IActionResult> AtualizarResponsavel(Responsavel responsavelAtualizado,String email)
        {
            var atualizado = await _responsavelService.AtualizarResponsavel(responsavelAtualizado,email);
      
>>>>>>> 0dc8ffcbb4653e197c1b30c1bab549d17695c087
            return Ok();
        }
    }
}
