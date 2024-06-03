using Microsoft.AspNetCore.Mvc;
using Template_Desafio_Ods_Comunidades.Models;
using Template_Desafio_Ods_Comunidades.Service;

namespace Template_Desafio_Ods_Comunidades.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OligarquiaController : ControllerBase
    {
        private readonly OligarquiaService _oligarquiaService;

        public OligarquiaController(OligarquiaService _oligarquiaService)
        {
            _oligarquiaService = _oligarquiaService;
        }

        [HttpGet("GetOligarquias")]
        public async Task<ActionResult<String>> GetOligarquias()
        {
            return await _oligarquiaService.ServiceTesteOligarquia();
        }

    }
}
