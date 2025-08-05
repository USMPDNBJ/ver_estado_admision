using System.ComponentModel.DataAnnotations;

namespace Dto.Request
{
    public class AlumnoByNumDocRequest
    {
        [Required]
        public required string NumeroDocumento { get; set; }
    }
}