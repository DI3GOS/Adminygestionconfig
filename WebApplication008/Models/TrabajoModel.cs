using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    public class TrabajoModel
    {
        [Key]        
        public int id_trabajo { get; set; }
        public int id_usuario { get; set; }
        public int id_materia { get; set; }

        [Required(ErrorMessage = "Ingresar Tipo de Trabajo")]        
        [Display(Name = "tipo_trabajo")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Debe ingresar maximo 50 caracteres")]
        [StringLength(50)]
        public string tipo_trabajo { get; set; }

        [Required(ErrorMessage = "Ingresar el Archivo")]
        [Display(Name = "archivo")]        
        [MaxLength(50, ErrorMessage = "Debe ingresar maximo 50 caracteres")]
        [StringLength(50)]
        public string archivo { get; set; }
        public System.DateTime fecha_entrega { get; set; }
    }
}