using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class Seguro
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Seg { get; set; }

        public decimal Cos_Men_Seg { get; set; }

        public DateTime Fec_Nac { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(16)]
        public string Num_Tar { get; set; }

        public bool Seg_Onc { get; set; }

        public bool Seg_Tar { get; set; }

    }
}