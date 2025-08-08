using System.ComponentModel.DataAnnotations;

namespace Dto.Response
{
    public class AlumnoByNumDocResponse
    {
        
        [Required]
        public string Nombre { get; set; }
        [Required]
        public  string ApellidoPaterno { get; set; }
        [Required]
        public  string ApellidoMaterno { get; set; }
        
        public  string EstadoAdmision { get; set; }
        [Required]
        public  string NumDoc { get; set; }
        [Required]
        public  string Sede { get; set; }
    }
}