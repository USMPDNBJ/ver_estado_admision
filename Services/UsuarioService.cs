using Data;
using Dto.Request;
using Dto.Response;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Security.Cryptography;
using System.Text;

public class UsuarioService : IUsuarioService
{
    private readonly ApiContext _context;

    public UsuarioService(ApiContext context)
    {
        _context = context;
    }

    public async Task<string?> ValidarCredenciales(UsuarioLoginReq request)
    {
        bool verify;
        Usuarios? user = await _context.Usuarios
                            .Where(a => a.Estado.Equals("1") && string.IsNullOrEmpty(a.Revision))
                          .FirstOrDefaultAsync(a => a.Usuario.Equals(request.Usuario));

        if (user == null)
        {
            return null;
        }else
        {
            verify = ValidarSHA256(request.Contrasena.ToUpper(), user.Contrasena.ToUpper());
        }

        if (!verify)
        {
            return "No coincide la contraseña";
        }

        return "Credenciales validas";;
    }
    static bool ValidarSHA256(string input, string hashEsperado)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF7.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            string hashCalculado2 = Convert.ToHexString(hashBytes); // Desde .NET 5 en adelante
            string hashCalculado = hashCalculado2.Substring(0, 40);
            return string.Equals(hashCalculado, hashEsperado, StringComparison.OrdinalIgnoreCase);
        }   
    }
}