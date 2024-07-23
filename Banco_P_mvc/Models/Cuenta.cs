using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class Cuenta
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(11)]
        public string Num_Cue { get; set; }

        public decimal Sal_Cue { get; set; }

        [Column(TypeName = "char")]
        [StringLength(11)]
        public string Ruc_Cli { get; set; }

        public decimal Mon_Ape { get; set; }

        public bool Cue_aho { get; set; }

        public bool Cue_Cor { get; set; }

        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Suc { get; set; }

        [ForeignKey("Cod_Suc")]
        public virtual Sucursal Sucursal { get; set; }
    }
}