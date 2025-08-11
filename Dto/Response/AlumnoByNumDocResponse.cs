using System.ComponentModel.DataAnnotations;

namespace Dto.Response
{
    public class AlumnoByNumDocResponse
    {
        
        public string Nombre { get; set; }
        public  string ApellidoPaterno { get; set; }
        public  string ApellidoMaterno { get; set; }        
        public  string EstadoAdmision { get; set; }
        public  string NumDoc { get; set; }
        public  string Sede { get; set; }
        public  string Modalidad { get; set; }
        public  string CodEspecialidad { get; set; }
        public  string Especialidad { get; set; }
    }
}