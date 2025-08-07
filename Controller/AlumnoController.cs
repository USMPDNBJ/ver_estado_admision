using Dto.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MyApp.Namespace
{
    [Route("api/alumno")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _AlumnoService;
        public AlumnoController(IAlumnoService AlumnoService)
        {
            _AlumnoService = AlumnoService;
        }
        [HttpGet("{numDoc}")]
        public async Task<IActionResult> ObtenerAlumnoByNumDoc(string numDoc)
        {
            var alumnoResponse = await _AlumnoService.ObtenerPorNumDocAsync(numDoc);
            if (alumnoResponse == null)
            {
                return BadRequest("Not found");
            }
            return Ok(alumnoResponse);
        }
    }
}
