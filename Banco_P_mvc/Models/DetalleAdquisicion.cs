using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class DetalleAdquisicion
    {
        [Key]
        public int Id_Det_Adq { get; set; }

        [Column(TypeName = "char")]
        [StringLength(8)]
        public string Dni_Cli { get; set; }

        [ForeignKey("Dni_Cli")]
        public virtual Cliente Cliente { get; set; }

        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Seg { get; set; }

        [ForeignKey("Cod_Seg")]
        public virtual Seguro Seguro { get; set; }

        public DateTime Fec_adq { get; set; }
    }
}