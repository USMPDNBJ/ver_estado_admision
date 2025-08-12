using System.ComponentModel.DataAnnotations;

namespace Dto.Request
{
    public class UsuarioLoginReq
    {
        [Required]
        public required string Usuario { get; set; }
        [Required]
        public required string Contrasena { get; set; }
    }
}