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
        public async Task<IActionResult> ValidarCredenciales(UsuarioLoginReq request)
        {
            if (request ==null)
            {
                return BadRequest("No se envio correctamente las credenciales");
            }

            string? response = await _usuarioService.ValidarCredenciales(request);
            return Ok(response);
        }
    }
}
