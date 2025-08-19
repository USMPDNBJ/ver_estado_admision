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
                            .Where(a => a.Estado.Equals("1")
                            //  && !string.IsNullOrEmpty(a.Revision)
                             )
                          .FirstOrDefaultAsync(a => a.Usuario.Equals(request.Usuario));
        UsuarioLoginRes response = new UsuarioLoginRes();
        if (user == null)
        {
            return null;
        }
        else
        {
            verify = ValidarSHA256(request.Contrasena, user.Contrasena);
        }

        if (!verify)
        {
            return null;
        }

        response.Codigo = "1P2e3r4m5i6t7i8d9o";
        response.Mensaje = "Credenciales validadas";

        return response;
    }

    static bool ValidarSHA256(string input, string userDB)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] data = Encoding.ASCII.GetBytes(input);
            byte[] result = sha1.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in result)
            {
                sb.Append(b.ToString("x2")); // formato hexadecimal con 2 dígitos
            }

            if (!sb.ToString().ToUpper().Equals(userDB.ToUpper()))
            {
                return false;
            }
            return true;
        }
    }
}

