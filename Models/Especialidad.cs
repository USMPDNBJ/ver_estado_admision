using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

    [Table("TA_ESPECIALIDAD")]
    public class Especialidad
    {
        [Key]
        [Column("COD_ESP")]
        public string CodEsp { get; set; }
        [Column("DES_ESP")]
        public string Descripcion { get; set; }
    }
}