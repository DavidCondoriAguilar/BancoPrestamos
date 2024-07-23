using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class Cliente
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(8)]
        public string Dni_Cli { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Nom_Cli { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Ape_Pat_Cli { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Ape_Mat_Cli { get; set; }

        [Column(TypeName = "char")]
        [StringLength(9)]
        public string Tel_Cli { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(70)]
        public string Cor_cli { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public string Dir_cli { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string Dis_cli { get; set; }

        public DateTime Fec_Ing_Cli { get; set; }

        public DateTime Fec_Nac_Cli { get; set; }

        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Emp { get; set; }

        [ForeignKey("Cod_Emp")]
        public virtual Empleado Empleado { get; set; }
    }
}