﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class LoginDBEntities : DbContext
{
    public LoginDBEntities()
        : base("name=LoginDBEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Asistencias> Asistencias { get; set; }
    public virtual DbSet<Calificaciones> Calificaciones { get; set; }
    public virtual DbSet<Materias> Materias { get; set; }
    public virtual DbSet<Materias_docentes> Materias_docentes { get; set; }
    public virtual DbSet<Materias_estudiantes> Materias_estudiantes { get; set; }
    public virtual DbSet<Trabajos> Trabajos { get; set; }
    public virtual DbSet<Usuarios> Usuarios { get; set; }
    public virtual DbSet<MateriaEstudiante> MateriaEstudiante { get; set; }
}
