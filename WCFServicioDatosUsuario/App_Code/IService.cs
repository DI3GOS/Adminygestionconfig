using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
	#region "Usuarios"

    [OperationContract]
    bool CrearUsuario(Usuarios usuarios);  //C

    [OperationContract]
    List<Usuarios> ConsultarUsuarios();     //R

    [OperationContract]
    Usuarios ConsultarUsuarioPorId(int id); //R

    [OperationContract]
    List<Usuarios> ConsultarUsuariosPorNombre(string name); // R

    [OperationContract]
    List<Usuarios> ConsultarUsuariosPorLogin(string login); // R

    [OperationContract]
    List<Usuarios> ConsultarUsuariosPorRol(string rol); //R

    [OperationContract]
    bool EditarUsuario(Usuarios users); //U

    [OperationContract]
    bool EliminarUsuarioPorId(int userId); //D

    #endregion

    #region "Trabajos"
    [OperationContract]
    bool CrearTrabajo(Trabajos trabajo);

    [OperationContract]
    bool EditarTrabajo(Trabajos trabajo);

    [OperationContract]
    List<Trabajos> ListarTrabajosPorIdMateria(int id_materia);

    [OperationContract]
    List<Trabajos> ListarTrabajosPorIdMateriaPorUsuario(int id_materia, int id_usuario);

    [OperationContract]
    bool EliminarTrabajoPorId(int idTrabajo);
    #endregion

    #region "Materias"
    [OperationContract]
    bool CrearMateria(Materias materia);

    [OperationContract]
    bool EditarMateria(Materias materia);

    [OperationContract]
    List<Materias> ListarMaterias();

    [OperationContract]
    List<Materias> ListarMateriasPorId(int idMateria);

    [OperationContract]
    bool EliminarMateriaPorId(int idMateria);
    #endregion

    #region "Asistencias"
    [OperationContract]
    bool CrearAsistencia(Asistencias asistencia);
    
    [OperationContract]
    bool EditarAsistencia(Asistencias asistencia);

    [OperationContract]
    List<Asistencias> ListarAsistencias();
    
    [OperationContract]
    List<Asistencias> ListarAsistenciasPorIdMateria(int idMateria);
    
    [OperationContract]
    bool EliminarAsistenciaPorId(int idAsistencia);

    #endregion


    #region "Calificaciones"
    [OperationContract]
    bool CrearCalificaciones(Calificaciones calificaciones);
    
    [OperationContract]
    bool EditarCalificacion(Calificaciones calificacion);

    [OperationContract]
    List<Calificaciones> ListarCalificaciones();

    [OperationContract]
    List<Calificaciones> ListarCalificacionesPorIdUsuario(int idUsuario);

    [OperationContract]
    bool EliminarCalificacionPorId(int idCalificacion);
    #endregion

    #region "Materias Estudiantes"
    [OperationContract]
    bool CrearMateriasEstudiantes(Materias_estudiantes materiaEstudiante);

    [OperationContract]
    bool EditarMateriaEstudiante(Materias_estudiantes materiaEstudiante);

    [OperationContract]
    List<Materias_estudiantes> ListarMateriasEstudiantes();

    [OperationContract]
    List<MateriaEstudiante> ListarMateriaEstudiante();

    [OperationContract]
    List<Materias_estudiantes> ListarMateriasEstudiantesPorId(int idUsuario);

    [OperationContract]
    bool EliminarMateriaEstudiantesPorId(int idMateriaEstudiante);
    #endregion

    #region "Materias Docentes"
    [OperationContract]
    bool CrearMateriasDocentes(Materias_docentes materiaDocente);

    [OperationContract]
    bool EditarMateriaDocente(Materias_docentes materiaDocente);

    [OperationContract]
    List<Materias_docentes> ListarMateriasDocentes();

    [OperationContract]
    List<Materias_docentes> ListarMateriasDocentesPorId(int idUsuario);

    [OperationContract]
    bool EliminarMateriaDocentesPorId(int idMateriaDocente);
    #endregion
}

[DataContract]
public class ListarTodosEmpleados
{
	[DataMember]
	public int EmpId { get; set; }
	[DataMember]
	public string Name { get; set; }
	[DataMember]
	public string Address { get; set; }
	[DataMember]
	public Nullable<int> Age { get; set; }
	[DataMember]
	public Nullable<decimal> Salary { get; set; }
	[DataMember]
	public string WorkType { get; set; }
}

[DataContract]
public class ListarTodosUsuarios
{
	[DataMember]
	public int Id { get; set; }
	[DataMember]
	public string UserName { get; set; }
	[DataMember]
	public string Password { get; set; }
	[DataMember]
	public string Nombre { get; set; }
	[DataMember]
	public string Apellido { get; set; }
	[DataMember]
	public string Email { get; set; }
}
