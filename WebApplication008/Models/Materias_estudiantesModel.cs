using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    public class Materias_estudiantesModel
    {
        [Key]
        public int Id_materia_estudiante { get; set; }

        [Required(ErrorMessage = "Ingrese Id de Materia")]
        [DataType(DataType.Text)]
        [Display(Name = "id_materia")]
        [StringLength(10)]
        public string Id_materia { get; set; }

        [Required(ErrorMessage = "Ingrese Id de Usuario")]
        [DataType(DataType.Text)]
        [Display(Name = "id_usuario")]
        [StringLength(10)]
        public string Id_Usuario { get; set; }
    }
}