using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    [MetadataType(typeof(EmployeeDetailsMetadata))]
    public partial class EmployeeDetails
    {        
        
    }
    
    public class EmployeeDetailsMetadata
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre")]
        [MinLength(5,ErrorMessage ="{0} Debe tener una longitud de mínimo 5 caracteres")]
        [Display(Name = "Nombre")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ingrese la direccion")]
        [Display(Name = "Direccion")]
        [MinLength(15, ErrorMessage = "{0} Debe tener una longitud de mínimo 15 caracteres")]         
        [StringLength(40)]
        public string Address { get; set; }

        [Display(Name = "Edad")]        
        public int Age { get; set; }
                
        [Display(Name = "Salario")]        
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Ingrese tipo de trabajo")]
        [Display(Name = "TipoTrabajo")]
        public string WorkType { get; set; }
    }
}