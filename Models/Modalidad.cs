using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

    [Table("TA_MODALIDAD")]
    public class Modalidad
    {
        [Key]
        [Column("COD_MOD")]
        public string CodMod { get; set; }
        [Column("DES_MOD")]
        public string Descripcion { get; set; }
    }
}