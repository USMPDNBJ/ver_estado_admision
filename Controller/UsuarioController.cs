using Dto.Request;
using Dto.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MyApp.Namespace
{
    [Route("api/alumno")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UsuarioLoginRes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ValidarCredenciales(UsuarioLoginReq request)
        {
            if (request == null)
            {
                return BadRequest("No se envio correctamente las credenciales");
            }

            UsuarioLoginRes? response = await _usuarioService.ValidarCredenciales(request);
            if (response == null)
            {
                return Unauthorized("Credenciales invalidas");
            }
            return Ok(response);
        }
    }
}
