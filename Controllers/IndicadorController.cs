using Microsoft.AspNetCore.Mvc;
using Template_Desafio_Ods_Comunidades.Models;
using Template_Desafio_Ods_Comunidades.Service;

namespace Template_Desafio_Ods_Comunidades.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndicadorController : ControllerBase
    {
        private readonly IndicadorService _indicadorService;

        public IndicadorController(IndicadorService indicadorService)
        {
            _indicadorService = indicadorService;
        }
        //Listar Todas as Listas de Indicadores.
        [HttpGet("GetAllIndicadores")]
        public async Task<ActionResult<Indicador>> GetAllIndicadores()
        {
            var indicadores = await _indicadorService.GetAllIndicadores();
            return Ok(indicadores);
        }
        //Listar Indicador por Sigla da Secretaria.
        [HttpGet("GetBySigla")]
        public ActionResult<Indicador> GetById(string SiglaSecretaria)
        {
            var Indicador = _indicadorService.GetBySiglaSecretaria(SiglaSecretaria);
            if (Indicador == null)
            {
                return NotFound();
            }
            return Ok(Indicador);
        }
        //Adicionar uma Secretaria.
        [HttpPost("Add")]
        public ActionResult Add(Indicador indicador)
        {

            _indicadorService.Add(indicador);
            return StatusCode(201);
        }
        //Atualizar uma Secretaria já Existente.
        [HttpPut("UpdateIndicador")]
        public async Task<IActionResult> Update(string SiglaSecretaria, Indicador indicador)
        {

            await _indicadorService.UpdateIndicador(SiglaSecretaria, indicador);
            return StatusCode(200);
        }
        [HttpDelete("DeleteIndicador")]
        public async Task<IActionResult> DeleteIndicador(string SiglaSecretaria)
        {
            var result = await _indicadorService.DeleteIndicador(SiglaSecretaria);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
