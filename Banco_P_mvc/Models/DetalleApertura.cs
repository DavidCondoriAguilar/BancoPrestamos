using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class DetalleApertura
    {
        [Key]
        public int Id_Ape { get; set; }

        [Column(TypeName = "char")]
        [StringLength(8)]
        public string Dni_Cli { get; set; }

        [ForeignKey("Dni_Cli")]
        public virtual Cliente Cliente { get; set; }

        [Column(TypeName = "char")]
        [StringLength(11)]
        public string Num_Cue { get; set; }

        [ForeignKey("Num_Cue")]
        public virtual Cuenta Cuenta { get; set; }

        public DateTime Fec_Ape { get; set; }
    }
}