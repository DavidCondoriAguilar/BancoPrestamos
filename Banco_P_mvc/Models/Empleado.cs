using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class Empleado
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Emp { get; set; }

        [Column(TypeName = "char")]
        [StringLength(8)]
        public string DNI_Emp { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Nom_Emp { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Ape_Pat_Emp { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Ape_Mat_Emp { get; set; }

        [Column(TypeName = "char")]
        [StringLength(9)]
        public string Tel_Emp { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(70)]
        public string Cor_Emp { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public string Dir_Emp { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string Dis_Emp { get; set; }

        public DateTime Fec_ing_Emp { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Car_Emp { get; set; }

        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Cod_Suc { get; set; }

        [ForeignKey("Cod_Suc")]
        public virtual Sucursal Sucursal { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre de usuario no puede exceder los 30 caracteres.")]
        public string UsuarioEmpleado { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria.")]
        [StringLength(100, ErrorMessage = "La clave no puede exceder los 100 caracteres.")]
        public string ClaveEmpleado { get; set; }
    }
}
