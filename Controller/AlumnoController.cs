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
        public IActionResult<Alumno> ObtenerAlumnoByNumDoc(string numDoc)
        {
            
        }
    }
}
