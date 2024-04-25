﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Asistencias
{
    public int id_asistencia { get; set; }
    public Nullable<int> id_usuario { get; set; }
    public Nullable<int> id_materia { get; set; }
    public Nullable<System.DateTime> fecha { get; set; }
    public string asistio { get; set; }
}

public partial class Calificaciones
{
    public int id_calificacion { get; set; }
    public Nullable<int> id_usuario { get; set; }
    public Nullable<int> id_materia { get; set; }
    public string tipo_actividad { get; set; }
    public Nullable<decimal> calificacion { get; set; }
}

public partial class EmployeeDetails
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Nullable<int> Age { get; set; }
    public Nullable<decimal> Salary { get; set; }
    public string WorkType { get; set; }
}

public partial class Materias
{
    public int id_materia { get; set; }
    public string nombre { get; set; }
    public string codigo { get; set; }
    public string descripcion { get; set; }
}

public partial class Materias_docentes
{
    public int id_materia_docente { get; set; }
    public Nullable<int> id_materia { get; set; }
    public Nullable<int> id_usuario { get; set; }
}

public partial class Materias_estudiantes
{
    public int id_materia_estudiante { get; set; }
    public Nullable<int> id_materia { get; set; }
    public Nullable<int> id_usuario { get; set; }
}

public partial class Productos
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public Nullable<double> Precio { get; set; }
    public Nullable<int> Stock { get; set; }
}

public partial class Trabajos
{
    public int id_trabajo { get; set; }
    public Nullable<int> id_usuario { get; set; }
    public Nullable<int> id_materia { get; set; }
    public string tipo_trabajo { get; set; }
    public string archivo { get; set; }
    public Nullable<System.DateTime> fecha_entrega { get; set; }
}

public partial class Usuario
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
}

public partial class Usuarios
{
    public int id_usuario { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string rol { get; set; }
    public string login { get; set; }
    public string clave { get; set; }
}