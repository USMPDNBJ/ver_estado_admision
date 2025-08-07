using Microsoft.EntityFrameworkCore;
using Models;

public interface IAlumnoService
{
    Task<Alumno?> ObtenerPorNumDocAsync(string numDoc);
}