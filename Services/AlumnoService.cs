using Data;
using Dto.Response;
using Microsoft.EntityFrameworkCore;
using Models;

public class AlumnoService : IAlumnoService
{
    private readonly ApiContext _context;

    public AlumnoService(ApiContext context)
    {
        _context = context;
    }

    public async Task<AlumnoByNumDocResponse?> ObtenerPorNumDocAsync(string numDoc)
    {
        Alumno? alumno = null;
        if (numDoc.Length == 8)
        {
            alumno = _context.Alumnos
            .FirstOrDefault(a => a.DNI.Equals(numDoc));
        }
        else if (numDoc.Length == 9)
        {
            alumno =  _context.Alumnos.FirstOrDefault(a => a.NumeroPasaporte.Equals(numDoc));
        }
        else
        {
            alumno = null;
        }
        AlumnoByNumDocResponse alumnoResponse = new AlumnoByNumDocResponse();
        return alumnoResponse;
    }
}