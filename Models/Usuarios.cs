using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("TA_USUARIO")]
    public class Usuarios
    {
        [Key]
        [Column("LOG_USU")]
        public string? Usuario { get; set; }
        [Column("CLA_USU")]
        public string? Contrasena { get; set; }
        [Column("EST_USU")]
        public string? Estado { get; set; }
        [Column("COD_REV")]
        public string? Revision { get; set; }
    }
}