using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

    public class PreInscripcion
    {
        [Key]
        [Column("ID")]
        public required int Id { get; set; }
        [Column("NOM")]
        public required string Nombre { get; set; }
        [Column("APE_PAT")]
        public required string ApellidoPaterno { get; set; }
        [Column("APE_MAT")]
        public required string ApellidoMaterno { get; set; }
        [Column("CODIGO_DE_CLAVE")]
        public  string NumeroDocumento { get; set; }
        [ForeignKey("Id")]
        public Postulante Postulante { get; set; }
    }
}