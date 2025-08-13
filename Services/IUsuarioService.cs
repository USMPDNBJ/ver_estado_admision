using Dto.Request;
using Dto.Response;
using Microsoft.EntityFrameworkCore;
using Models;

public interface IUsuarioService
{
    Task<UsuarioLoginRes?> ValidarCredenciales(UsuarioLoginReq request);
}