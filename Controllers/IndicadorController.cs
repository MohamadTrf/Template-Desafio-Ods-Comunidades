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

        [HttpPost("GetAllIndicadores")]
        public async Task<ActionResult<Indicador>> GetAllIndicadores()
        {
            var indicadores = await _indicadorService.GetAllIndicadores();
            return Ok(indicadores);
        }
    }
}
