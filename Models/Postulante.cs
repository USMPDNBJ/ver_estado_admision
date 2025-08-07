using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Postulante
    {
        [Key]
        [Column("ID_PREINS")]
        public int Id { get; set; }
        [Column("RESULTADO")]
        public string Resultado { get; set; }
        public PreInscripcion PreInscripcion { get; set; }
    }
}