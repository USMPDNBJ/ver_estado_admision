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
        var codModPermitidos = new[] { "001", "111", "110", "002", "026", "008", "043", "143", "049", "147", "145", "033", "142", "144", "146", "141" };
        var preInscripcion = await _context.Preinscripcion
            .Include(a => a.Postulante)
            .Include(a => a.Sede)
            .Include(a => a.Vacante)
            .Where(a => (a.Vacante.SemApe.Trim().Equals("20252") || a.Vacante.SemApe.Trim().Equals("20261")) &&
        codModPermitidos.Contains(a.Vacante.Modalidad.CodMod.Trim()) &&
        a.NumeroDocumento == numDoc && a.Vacante.Especialidad.CodGra.Trim().Equals("001"))
                        .Select(a => new AlumnoByNumDocResponse
                        {
                            NumDoc = a.NumeroDocumento,
                            Nombre = a.Nombre,
                            ApellidoMaterno = a.ApellidoMaterno,
                            ApellidoPaterno = a.ApellidoPaterno,
                            EstadoAdmision = a.Postulante != null
                             ? (a.Postulante.Resultado.ToUpper().Trim().Equals("ADMITIDO") ? "Aprobado" :
               a.Postulante.Resultado.ToUpper().Trim().Equals("NO ADMITIDO") ? "Desaprobado" : "No especificado")
            : "No especificado",
                            Modalidad = a.Vacante.Modalidad.Descripcion,
                            Sede = a.Sede.Descripcion,
                            CodEspecialidad = a.Vacante.Especialidad.CodEsp.Trim(),
                            Especialidad = a.Vacante.Especialidad.Descripcion
                        })
            .FirstOrDefaultAsync();

        if (preInscripcion == null)
        {
            return null;
        }

        return preInscripcion;
    }
}