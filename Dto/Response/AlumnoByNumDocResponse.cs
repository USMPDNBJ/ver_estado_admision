using System.ComponentModel.DataAnnotations;

namespace Dto.Response
{
    public class AlumnoByNumDocResponse
    {
        public AlumnoByNumDocResponse()
        {
            
        }
        
        [Required]
        public string Nombre { get; set; }
        [Required]
        public  string ApellidoPaterno { get; set; }
        [Required]
        public  string ApellidoMaterno { get; set; }
        [Required]
        public  string EstadoAdmision { get; set; }
        [Required]
        public  string numDoc { get; set; }
    }
}