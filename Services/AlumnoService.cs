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
            .Include(a => a.Sede)
            .Where(a => a.FechaCreacion > new DateTime(2025, 1, 1) && a.NumeroDocumento == numDoc)
                        .Select(a => new AlumnoByNumDocResponse
                        {
                            NumDoc = a.NumeroDocumento,
                            Nombre = a.Nombre,
                            ApellidoMaterno = a.ApellidoMaterno,
                            ApellidoPaterno = a.ApellidoPaterno,
                            EstadoAdmision = a.Postulante != null && a.Postulante.Resultado != null
                             ? (a.Postulante.Resultado.ToUpper().Equals("ADMITIDO") ? "Aprobado" :
               a.Postulante.Resultado.ToUpper().Equals("NO ADMITIDO") ? "Desaprobado" : "No especificado")
            : "No especificado",
                            Sede =  a.Sede.Descripcion
                        })
            .FirstOrDefaultAsync();

        if (preInscripcion == null)
        {
            return null;
        }

        return preInscripcion;
    }
}