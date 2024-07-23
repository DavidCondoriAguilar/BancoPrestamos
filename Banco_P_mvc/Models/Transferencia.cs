using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class Transferencia
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(7)]
        public string Cod_Tra { get; set; }

        public decimal Mon_Tra { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Cue_Tra { get; set; }

        public DateTime Fec_Tra { get; set; }

        public bool Tra_Int { get; set; }

        [Column(TypeName = "char")]
        [StringLength(11)]
        public string Num_Cue { get; set; }

        [ForeignKey("Num_Cue")]
        public virtual Cuenta Cuenta { get; set; }
    }
}