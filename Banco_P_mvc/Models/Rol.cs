using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banco_P_mvc.Models
{
    public class Rol
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodRol { get; set; }
        [Required]
        [MaxLength(60, ErrorMessage = "El campo {0} de de tebe como " +
            "maximo {1}")]
        [StringLength(60)]
        [Display(Name = "Nombre")]
        public string NombreRol { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool EstdRol { get; set; }
    }
}