using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

    [Table("TA_VACANTE")]
    public class Vacante
    {
        [Key]
        [Column("COD_VAC")]
        public required int CodVac { get; set; }
        [Column("SEM_APE")]
        public string SemApe { get; set; }
        [ForeignKey("COD_ESP")]
        public Especialidad Especialidad { get; set; }
        [ForeignKey("COD_MOD")]
        public Modalidad Modalidad { get; set; }
    }
}