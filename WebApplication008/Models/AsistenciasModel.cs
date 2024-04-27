using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{    
    public class AsistenciasModel
    {

        public AsistenciasModel()
        {
            this.Id_usuario = 0;
            this.Id_materia = 0;
        }

        [Key]
        public int Id_asistencia { get; set; }
                
        public int Id_usuario { get; set; }
        
        public int Id_materia { get; set; }
                
        public string Fecha { get; set; }

        [Required(ErrorMessage = "Ingrese asistencia Si/No")]        
        [Display(Name = "asistio")]
        [MinLength(2, ErrorMessage = "Debe ingresar minimo 2 caracteres")]
        [MaxLength(5, ErrorMessage = "Debe ingresar maximo 5 caracteres")]
        [StringLength(5)]
        public string Asistio { get; set; }
    }
}