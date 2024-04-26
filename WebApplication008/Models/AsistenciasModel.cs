using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{    
    public class AsistenciasModel
    {
        [Key]
        public int Id_asistencia { get; set; }

        [Required(ErrorMessage = "Ingresar Id Usuario")]
        [DataType(DataType.Text)]
        [Display(Name = "id_usuario")]
        [MinLength(3, ErrorMessage = "Debe ingresar el codigo del usuario")]
        [MaxLength(15, ErrorMessage = "Debe ingresar maximo 15 caracteres")]
        [StringLength(15)]
        public string Id_usuario { get; set; }

        [Required(ErrorMessage = "Ingresar Id Materia")]
        [DataType(DataType.Text)]
        [Display(Name = "id_materia")]
        [MinLength(3, ErrorMessage = "Debe ingresar el codigo de la materia")]
        [MaxLength(15, ErrorMessage = "Debe ingresar maximo 15 caracteres")]
        [StringLength(15)]
        public string Id_materia { get; set; }

        [Required(ErrorMessage = "Ingresar Fecha")]
        [DataType(DataType.Text)]
        [Display(Name = "fecha")]
        [MaxLength(10, ErrorMessage = "Debe ingresar maximo 10 caracteres")]
        [StringLength(10)]
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