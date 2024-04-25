using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    public class MateriaModel
    {
        [Key]
        public int Id_materia { get; set; }

        [Required(ErrorMessage = "Ingresar Materia")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        [MinLength(3, ErrorMessage = "Debe ingresar la materia")]
        [MaxLength(50, ErrorMessage = "Debe ingresar maximo 50 caracteres")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese Codigo")]
        [DataType(DataType.Text)]
        [Display(Name = "Codigo")]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Ingresa Descripcion")]
        [DataType(DataType.Text)]
        [Display(Name = "Descripcion")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 caracteres")]
        [MaxLength(60, ErrorMessage = "Debe ingresar maximo 60 caracteres")]
        [StringLength(60)]
        public string Descripcion { get; set; }
    }
}