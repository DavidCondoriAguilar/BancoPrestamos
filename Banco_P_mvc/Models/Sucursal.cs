using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class Sucursal
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Suc { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Nom_Suc { get; set; }

        [Column(TypeName = "char")]
        [StringLength(3)]
        public string Afo_Suc { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Dis_Suc { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string Pro_Suc { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string Dep_Suc { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public string Dir_Suc { get; set; }
    }
}