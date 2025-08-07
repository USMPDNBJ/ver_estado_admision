using Dto.Response;
using Microsoft.EntityFrameworkCore;
using Models;

public interface IAlumnoService
{
    Task<AlumnoByNumDocResponse?> ObtenerPorNumDocAsync(string numDoc);
}