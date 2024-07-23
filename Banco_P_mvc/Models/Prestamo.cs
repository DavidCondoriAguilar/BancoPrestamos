using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class Prestamo
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Pre { get; set; }

        public decimal Mon_Pre { get; set; }

        public bool Pre_Est { get; set; }

        public bool Com_Deu { get; set; }

        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Suc { get; set; }

        [ForeignKey("Cod_Suc")]
        public virtual Sucursal Sucursal { get; set; }
    }
}