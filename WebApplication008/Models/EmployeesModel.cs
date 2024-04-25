using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    public class EmployeesModel
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre")]
        [MinLength(3, ErrorMessage = "{0} Debe tener una longitud de mínimo 3 caracteres")]
        [Display(Name = "Nombre")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ingrese la direccion")]
        [Display(Name = "Direccion")]
        [MinLength(10, ErrorMessage = "{0} Debe tener una longitud de mínimo 10 caracteres")]
        [StringLength(40)]
        public string Address { get; set; }

        [Display(Name = "Edad")]        
        public Nullable<int> Age { get; set; }

        [Display(Name = "Salario")]        
        public Nullable<decimal> Salary { get; set; }

        [Required(ErrorMessage = "Ingrese tipo de trabajo")]
        [Display(Name = "Tipo Trabajo")]
        public string WorkType { get; set; }
    }    
}