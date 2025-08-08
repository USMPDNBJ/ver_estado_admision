using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Sede
    {
        [Key]
        [Column("COD_SED")]
        public int Id { get; set; }
        [Column("DES_SED")]
        public string Descripcion { get; set; }
    }
}