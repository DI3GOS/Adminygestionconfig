﻿using System;
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

        public int Id_materia { get; set; }
                
        public int Id_Usuario { get; set; }
    }
}