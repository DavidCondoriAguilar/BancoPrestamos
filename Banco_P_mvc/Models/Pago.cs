using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class Pago
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(7)]
        public string Cod_Pgo { get; set; }

        [Column(TypeName = "char")]
        [StringLength(2)]
        public string Num_Cuo_Pgo { get; set; }

        public DateTime Fec_Pro_Pgo { get; set; }

        public decimal Mon_Pgo { get; set; }

        public DateTime Fec_Rea_Pgo { get; set; }

        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Pre { get; set; }

        [ForeignKey("Cod_Pre")]
        public virtual Prestamo Prestamo { get; set; }
    }
}