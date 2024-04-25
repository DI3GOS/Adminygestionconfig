using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingresa Nombre de Usuario")]
        [DataType(DataType.Text)]
        [Display(Name = "Usuario")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 caracteres")]
        [MaxLength(10, ErrorMessage = "Debe ingresar maximo 10 caracteres")]
        [StringLength(10)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ingrese Clave")]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        [StringLength(10)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ingresa Nombre(s)")]
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

        [Required(ErrorMessage = "Ingresa Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]        
        [MaxLength(40, ErrorMessage = "Debe ingresar maximo 40 caracteres")]
        [StringLength(40)]
        public string Email { get; set; }
    }
}