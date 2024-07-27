using Microsoft.AspNetCore.Mvc;
using System;
using Template_Desafio_Ods_Comunidades.Models;
using Template_Desafio_Ods_Comunidades.Service;

namespace Template_Desafio_Ods_Comunidades.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class SecretariaController : ControllerBase
    {
        private readonly SecretariaService _service;

        public SecretariaController(SecretariaService service)
        {
            _service = service;
        }
        
        
        //Lista Todas as Secretarias.
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Secretaria>> GetAll()
        {
            var secretarias = _service.GetAll();
            if (secretarias == null || !secretarias.Any())
            {
                return NoContent();
            }
            return Ok(secretarias);
        }
        //Lista as Secretarias por sigla.
        [HttpGet("GetBySigla")]
        public ActionResult<Secretaria> GetById(string SiglaSecretaria)
        {
            var secretaria = _service.GetBySiglaSecretaria(SiglaSecretaria);
            if (secretaria == null)
            {
                return NotFound();
            }
            return Ok(secretaria);
        }
        //Adicionar uma Secretaria.
        [HttpPost("Add")]
        public ActionResult Add(Secretaria secretaria)
        {

            _service.Add(secretaria);
            return StatusCode(201);
        }
        //Atualizar uma Secretaria já Existente.
        [HttpPut("Update")]
        public  async Task<IActionResult> Update(string SiglaSecretaria, Secretaria secretariaAtualizada)
        {

            var sucesso = await _service.Update(SiglaSecretaria, secretariaAtualizada);

            if (sucesso)
            {
                return Ok("Secretaria atualizada com sucesso!");
            }
            else
            {
                return NotFound("Secretaria não encontrada ou erro na atualização.");
            }
        }
      
    }

}
