using EnvioCorreo.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EnvioCorreo.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IServicioEmail servicioEmail;

        public EmailsController(IServicioEmail servicioEmail)
        {
            this.servicioEmail = servicioEmail;
        }

        [HttpGet("enviar")]
        public async Task<ActionResult> Enviar(
            [FromQuery] string email,
            [FromQuery] string tema,
            [FromQuery] string cuerpo)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(tema) || string.IsNullOrWhiteSpace(cuerpo))
            {
                return BadRequest("Todos los parámetros son obligatorios.");
            }

            await servicioEmail.EnviarEmail(email, tema, cuerpo);
            return Ok("Correo enviado correctamente.");
        }
    }
}

