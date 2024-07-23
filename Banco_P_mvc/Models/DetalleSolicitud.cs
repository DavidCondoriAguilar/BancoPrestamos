using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Banco_P_mvc.Models
{
    public class DetalleSolicitud
    {
        [Key]
        public int Id_Solicitud { get; set; }

        [Column(TypeName = "char")]
        [StringLength(8)]
        public string Dni_Cli { get; set; }

        [ForeignKey("Dni_Cli")]
        public virtual Cliente Cliente { get; set; }

        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Pre { get; set; }

        [ForeignKey("Cod_Pre")]
        public virtual Prestamo Prestamo { get; set; }

        public DateTime Fec_Sol { get; set; }
    }
}