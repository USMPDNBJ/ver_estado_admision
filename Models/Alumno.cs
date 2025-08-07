namespace Models{

    public class Alumno
    {
        public required string Nombre { get; set; }
        public required string ApellidoPaterno { get; set; }
        public required string ApellidoMaterno { get; set; }
        public required string DNI { get; set; }
        public required string NumeroPasaporte { get; set; }
    }
}