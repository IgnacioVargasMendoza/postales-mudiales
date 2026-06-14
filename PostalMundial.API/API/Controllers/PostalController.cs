using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalController : Controller, IPostalController
    {
        private IPostalFlujo _postalFlujo;
        private ILogger<IPostalController> _logger;

        public PostalController(IPostalFlujo postalFlujo, ILogger<IPostalController> logger)
        {
            _postalFlujo = postalFlujo;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] PostalRequest postal)
        {
            var result = await _postalFlujo.Agregar(postal);
            return CreatedAtAction(nameof(Obtener), new { Id = result }, result);
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] PostalRequest postal)
        {
            var result = await _postalFlujo.Editar(Id, postal);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            var result = await _postalFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var result = await _postalFlujo.Obtener();
            if (result == null || !result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var result = await _postalFlujo.Obtener(Id);
            return Ok(result);
        }

        [HttpGet("faltantes")]
        public async Task<IActionResult> ObtenerFaltantes()
        {
            var result = await _postalFlujo.ObtenerFaltantes();
            return Ok(result);
        }
    }
}
