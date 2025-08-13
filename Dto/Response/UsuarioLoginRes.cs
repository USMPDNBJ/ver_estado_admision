using System.ComponentModel.DataAnnotations;

namespace Dto.Request
{
    public class UsuarioLoginRes
    {
        public  string Mensaje { get; set; }
        public string Codigo { get; set; }
    }
}