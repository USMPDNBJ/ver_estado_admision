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
        if (string.IsNullOrWhiteSpace(numDoc) || (numDoc.Length != 8 && numDoc.Length != 9))
        {
            return null;
        }

        var preInscripcion = await _context.Preinscripcion
            .Include(a => a.Postulante)
            .FirstOrDefaultAsync(a => a.NumeroDocumento == numDoc)
            ;

        if (preInscripcion == null)
        {
            return null;
        }

        var alumnoResponse = new AlumnoByNumDocResponse
        {
            NumDoc = preInscripcion.NumeroDocumento,
            Nombre = preInscripcion.Nombre,
            ApellidoMaterno = preInscripcion.ApellidoMaterno,
            ApellidoPaterno = preInscripcion.ApellidoPaterno,
            EstadoAdmision = preInscripcion.Postulante?.Resultado?.ToUpper() switch
            {
                "ADMITIDO" => "Aprobado",
                "NO ADMITIDO" => "Desaprobado",
                _ => "No especificado"
            }
        };
        return alumnoResponse;
    }
}