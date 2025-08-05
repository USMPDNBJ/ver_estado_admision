using System.ComponentModel.DataAnnotations;

namespace Dto.Response
{
    public class AlumnoByNumDocResponse
    {
        [Required]
        public required string Nombre { get; set; }
        [Required]
        public required string ApellidoPaterno { get; set; }
        [Required]
        public required string ApellidoMaterno { get; set; }
        [Required]
        public required string EstadoAdmision { get; set; }
    }
}