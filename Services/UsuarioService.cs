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

    public async Task<UsuarioLoginRes?> ValidarCredenciales(UsuarioLoginReq request)
    {
        bool verify = false;
        string msg = "";
        Usuarios? user = await _context.Usuarios
                            .Where(a => a.Estado.Equals("1") && !string.IsNullOrEmpty(a.Revision))
                          .FirstOrDefaultAsync(a => a.Usuario.Equals(request.Usuario));
        UsuarioLoginRes response = new UsuarioLoginRes();
        if (user == null)
        {
            return null;
        }
        else
        {
            verify = ValidarSHA256(request.Contrasena.ToUpper(), user.Contrasena.ToUpper());
        }

        if (!verify)
        {
            return null;
        }
        
        response.Codigo = "1P2e3r4m5i6t7i8d9o";
        response.Mensaje = "Credenciales validadas";

        return response;
    }

    static bool ValidarSHA256(string input, string hashEsperado)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            string hashCalculado2 = Convert.ToHexString(hashBytes); // Desde .NET 5 en adelante
            string hashCalculado = hashCalculado2.Substring(0, 40);
            return string.Equals(hashCalculado, hashEsperado, StringComparison.OrdinalIgnoreCase);
        }
    }
}