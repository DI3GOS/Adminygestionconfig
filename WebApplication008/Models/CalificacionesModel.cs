using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    public class CalificacionesModel
    {
        [Key]
        public int Id_calificacion { get; set; }

        public int Id_usuario { get; set; }

        public int Id_materia { get; set; }

        public string tipo_actividad { get; set; }

        public decimal calificacion { get; set; }
    }
}