using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.Util;

namespace WebApplication008.Models
{
    public class UsuariosModel
    {
        [Key]
        public int Id_usuario { get; set; }

        [Required(ErrorMessage = "Ingresa Nombre de Usuario")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 caracteres")]
        [MaxLength(40, ErrorMessage = "Debe ingresar maximo 40 caracteres")]
        [StringLength(40)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingresa Apellido(s)")]
        [DataType(DataType.Text)]
        [Display(Name = "Apellido")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 caracteres")]
        [MaxLength(40, ErrorMessage = "Debe ingresar maximo 40 caracteres")]
        [StringLength(40)]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Debe elegir un Rol")]
        [DataType(DataType.Text)]
        [Display(Name = "Rol")]
        public string Rol { get; set; }
        /*
        //public List<Rol> ObtenerRoles
        //{
        //    get
        //    {
        //        var roles = new List<Rol>()
        //    {
        //        Rol.Administrador,
        //        Rol.Docente,
        //        Rol.Estudiante
        //    };
        //        return roles.ToList();
        //    }
        //}

        //public enum Rol
        //{
        //    Administrador = 1,
        //    Docente = 2,
        //    Estudiante = 3
        //}
        */

        [Required(ErrorMessage = "Ingresar Login")]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        [MinLength(5, ErrorMessage = "Debe ingresar minimo 5 caracteres")]
        [MaxLength(45, ErrorMessage = "Debe ingresar maximo 45 caracteres")]
        [StringLength(45)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Ingrese Clave")]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        [MinLength(8, ErrorMessage = "Debe ingresar minimo 8 caracteres")]
        [MaxLength(25, ErrorMessage = "Debe ingresar maximo 25 caracteres")]
        public string Password { get; set; }        
    }
}