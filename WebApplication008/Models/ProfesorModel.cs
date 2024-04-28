using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    public class ProfesorModel
    {
        public ProfesorModel()
        {
            this.id_materia = 0;
            this.id_usuario = 0;
        }

        public int id_materia_docente { get; set; }
        public int id_materia { get; set; }
        public int id_usuario { get; set; }
    }

}