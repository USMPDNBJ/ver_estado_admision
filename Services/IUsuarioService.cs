using Dto.Request;
using Dto.Response;
using Microsoft.EntityFrameworkCore;
using Models;

public interface IUsuarioService
{
    Task<string?> ValidarCredenciales(UsuarioLoginReq request);
}