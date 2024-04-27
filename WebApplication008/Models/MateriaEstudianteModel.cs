using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    public class MateriaEstudianteModel
    {        
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Ingrese el Rol del usuario")]
        [DataType(DataType.Text)]
        [Display(Name = "Rol")]
        [StringLength(20)]
        public string Rol { get; set; }

        //[Required(ErrorMessage = "Ingresar Nombre")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Debe ingresar maximo 50 caracteres")]
        [StringLength(50)]
        public string Nombre { get; set; }

        //[Required(ErrorMessage = "Ingresar Apellido")]
        [DataType(DataType.Text)]
        [Display(Name = "Apellido")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Debe ingresar maximo 50 caracteres")]
        [StringLength(50)]
        public string Apellido { get; set; }

        //[Required(ErrorMessage = "Ingresar Materia")]
        [DataType(DataType.Text)]
        [Display(Name = "Materia")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Debe ingresar maximo 50 caracteres")]
        [StringLength(50)]
        public string Materia { get; set; }

        public int Id_usuario { get; set; }

        public int Id_materia { get; set; }
    }
}