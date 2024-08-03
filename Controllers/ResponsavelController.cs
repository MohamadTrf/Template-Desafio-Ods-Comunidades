using Microsoft.AspNetCore.Mvc;
using Template_Desafio_Ods_Comunidades.Models;
using Template_Desafio_Ods_Comunidades.Service;
using System;
using System.Threading.Tasks;

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

        //Lista Todas as Secretarias.
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var Responsavel = await _responsavelService.GetAll();
            return Ok(Responsavel);
        }
        
        //Lista todos os Responsáveis da sigla digitada.
        [HttpGet("GetBySigla")]
        public ActionResult<Responsavel> GetById(string SiglaSecretaria)
        {
            var Responsavel = _responsavelService.GetBySigla(SiglaSecretaria);
            if (Responsavel == null)
            {
                return NotFound();
            }
            return Ok(Responsavel);
        }

        [HttpPost("CadastrarResponsavel")]
        public async Task<ActionResult> CadastrarResponsavel(Responsavel responsavel)
        {
            try
            {
                var result = await _responsavelService.CadastrarResponsavel(responsavel);
                return StatusCode(201, result);
            }
            catch (ArgumentException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao salvar as mudanças. Tente novamente mais tarde.", details = ex.Message });
            }
        }

        [HttpPut("Desativar/{email}")]
        public async Task<IActionResult> DesativarResponsavel(string email, bool Active)
        {
            try
            {
                var result = await _responsavelService.DesativarResponsavel(email, Active);
                return Ok(new { message = "Status do responsável atualizado com sucesso.", result });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }



        [HttpPut("AtualizarResponsavel")]
        public async Task<IActionResult> AtualizarResponsavel(string SiglaSecretaria,string email, Responsavel responsavel)
        {
            await _responsavelService.AtualizarResponsavel(SiglaSecretaria, email, responsavel);
            return StatusCode(200);
        }
    }
}
