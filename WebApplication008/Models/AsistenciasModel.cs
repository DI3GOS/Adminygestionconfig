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

        [Required(ErrorMessage = "Ingrese asistencia")]
        [DataType(DataType.Text)]
        [Display(Name = "asistio")]
        [MinLength(5, ErrorMessage = "Debe ingresar minimo 4 caracter")]
        [MaxLength(5, ErrorMessage = "Debe ingresar maximo 5 caracter")]
        [StringLength(5)]
        public string Asistio { get; set; }

    }
}