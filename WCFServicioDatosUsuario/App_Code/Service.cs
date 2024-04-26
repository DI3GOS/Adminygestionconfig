using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Description;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	LoginDBEntities DBcontext = new LoginDBEntities();

	#region Empleado

	//CREATE 
	public int InsertarEmpleado(EmployeeDetails empleado)
	{
		int Retval = 0;

		try
		{
			EmployeeDetails newEmp = new EmployeeDetails();

			//newEmp.Id = empleado.Id; //identity
			newEmp.Name = empleado.Name.Trim();
			newEmp.Address = empleado.Address.Trim();
			newEmp.Age  = empleado.Age;
			newEmp.Salary = empleado.Salary;
			newEmp.WorkType = empleado.WorkType.Trim();			

			DBcontext.EmployeeDetails.Add(newEmp);
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}


	}

	//READ ALL EMPLOYEES
	public List<EmployeeDetails> ListarTodosEmpleados()
	{
		List<EmployeeDetails> emplst = new List<EmployeeDetails>();
		try
		{
			var lstEmp = from k in DBcontext.EmployeeDetails select k;

			foreach (var item in lstEmp)
			{
				EmployeeDetails empl = new EmployeeDetails();

				empl.EmpId = item.EmpId;
				empl.Name = item.Name.Trim();				
				empl.Address = item.Address.Trim();
				empl.Age = item.Age;				
				empl.Salary = item.Salary;
				empl.WorkType = item.WorkType.Trim();
				
				emplst.Add(empl);
			}
			return emplst;
		}
		catch (Exception)
		{
			return emplst;
		}
	}

	//READ EMPLOYEE BY empId
	public EmployeeDetails ObtenerEmpleadoPorId(int empId)
	{
		var lstEmp = from k in DBcontext.EmployeeDetails where k.EmpId == empId select k;
		EmployeeDetails empl = new EmployeeDetails();
		try
		{
			foreach (var item in lstEmp)
			{
				empl.EmpId = item.EmpId;
				empl.Name = item.Name.Trim();
				empl.Address = item.Address.Trim();
				empl.Age = item.Age;
				empl.Salary = item.Salary;
				empl.WorkType = item.WorkType.Trim();
			}
			return empl;
		}
		catch (Exception)
		{
			return empl;
		}
	}

	//READ EMPLOYEE BY NameEmployee
	public List<EmployeeDetails> ObtenerEmpleadosPorNombre(string Name)
	{
		var lstEmp = from k in DBcontext.EmployeeDetails where k.Name.Contains(Name.ToString()) select k;		
		List<EmployeeDetails> lstEmpl = new List<EmployeeDetails>();
		try
		{
			foreach (var item in lstEmp)
			{
				EmployeeDetails empl = new EmployeeDetails(); //para que cree el nuevo usuario
				empl.EmpId = item.EmpId;
				empl.Name = item.Name.Trim();
				empl.Address = item.Address.Trim();
				empl.Age = item.Age;
				empl.Salary = item.Salary;
				empl.WorkType = item.WorkType.Trim();
				lstEmpl.Add(empl);
			}
			return lstEmpl;
		}
		catch (Exception)
		{
			return lstEmpl;
		}
	}

	//UPDATE EMPLOYEE BY EMPLOYEE
	public int ModificarEmpleado(EmployeeDetails emp)
	{
		int Retval = 0;
		try
		{
			EmployeeDetails empl = new EmployeeDetails();
			empl.EmpId = emp.EmpId;
			empl.Name = emp.Name.Trim();
			empl.Address = emp.Address.Trim();
			empl.Age = emp.Age;
			empl.Salary = emp.Salary;
			empl.WorkType = emp.WorkType.Trim();

			DBcontext.Entry(empl).State = EntityState.Modified;
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}
	}

	//DELETE EMPLOYEE BY empId
	public int BorrarEmpleadoPorId(int empId)
	{
		int Retval = 0;
		try
		{
			EmployeeDetails empl = new EmployeeDetails();
			empl.EmpId = empId;
			DBcontext.Entry(empl).State = EntityState.Deleted;
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}
	}

	#endregion

	#region Usuario

	//CREATE 
	public int InsertarUsuario(Usuario usuario)
	{
		int Retval = 0;

		try
		{
			var newuser = new Usuario();

			//newuser.Id = 0;  //identity
			newuser.Nombre = usuario.Nombre.Trim();
			newuser.Password = usuario.Password.Trim();
			newuser.UserName = usuario.UserName.Trim();
			newuser.Apellido = usuario.Apellido.Trim();
			newuser.Email = usuario.Email.Trim();

			DBcontext.Usuario.Add(newuser);
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}
	}

	//READ ALL USERS
	public List<Usuario> ListarTodosUsuarios()
	{
		LoginDBEntities tstDb = new LoginDBEntities();
		List<Usuario> userlst = new List<Usuario>();

		var lstUsr = from k in tstDb.Usuario select k;

		foreach (var item in lstUsr)
		{			
			Usuario usr = new Usuario();
			usr.Id = item.Id;
			usr.Nombre = item.Nombre.Trim();
			usr.UserName = item.UserName.Trim();
			usr.Password = item.Password.Trim();
			usr.Apellido = item.Apellido.Trim();
			usr.Email = item.Email.Trim();

			userlst.Add(usr);
		}
		return userlst;
	}

	//READ USER BY ID
	public Usuario ObtenerUsuarioPorId(int id)
	{
		LoginDBEntities tstDb = new LoginDBEntities();

		var lstUsr = from k in tstDb.Usuario where k.Id == id select k;
		Usuario usr = new Usuario();

		foreach (var item in lstUsr)
		{
			usr.Id = item.Id;
			usr.Nombre = item.Nombre.Trim();
			usr.UserName = item.UserName.Trim();
			usr.Password = item.Password.Trim();
			usr.Apellido = item.Apellido.Trim();
			usr.Email = item.Email.Trim();
		}
		return usr;
	}

	//READ USER BY NAME
	public List<Usuario> ObtenerUsuariosPorNombre(string Name)
	{		
		var lstUsr = from k in DBcontext.Usuario where k.Nombre.Contains(Name.ToString()) select k;		
		List<Usuario> lstUser = new List<Usuario>();

		foreach (var item in lstUsr)
		{
			Usuario usr = new Usuario();
			usr.Id = item.Id;
			usr.Nombre = item.Nombre.Trim();
			usr.UserName = item.UserName.Trim();
			usr.Password = item.Password.Trim();
			usr.Apellido = item.Apellido.Trim();
			usr.Email = item.Email.Trim();
			lstUser.Add(usr);
		}
		return lstUser;
	}

	//UPDATE USER BY USER
	public int ModificarUsuario(Usuario user)
	{
		int Retval = 0;
		try
		{
			LoginDBEntities tstDb = new LoginDBEntities();
			Usuario usrdtl = new Usuario();
			usrdtl.Id = user.Id;
			usrdtl.Nombre = user.Nombre.Trim();
			usrdtl.UserName = user.UserName.Trim();
			usrdtl.Password = user.Password.Trim();
			usrdtl.Apellido = user.Apellido.Trim();
			usrdtl.Email = user.Email.Trim();

			tstDb.Entry(usrdtl).State = EntityState.Modified;
			Retval = tstDb.SaveChanges();
			return Retval;
		}
		catch (Exception ex)
		{
			//Cuando se tiene validacion de base de datos longitud saca error .Net
			//El campo Name debe ser un tipo de cadena o matriz con una longitud máxima de '10'.
			return Retval;
		}
	}

	//DELETE USER BY ID
	public int BorrarUsuarioPorId(int userId)
	{
		int Retval = 0;
		try
		{
			Usuario Myuser = new Usuario();
			Myuser.Id = userId;
			DBcontext.Entry(Myuser).State = EntityState.Deleted;
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}
	}

    #endregion

    #region "Usuarios"

    //CREATE Usuarios
    public bool CrearUsuario(Usuarios usuarios)
    {
        int Retval = 0;
        bool bandera = false;

        try
        {
            var newuser = new Usuarios();

            //newuser.Id = 0;  //identity
            //newuser.id_usuario = Convert.ToInt32(usuarios.id_usuario.ToString().Trim());
            newuser.nombre = usuarios.nombre.Trim();
            newuser.apellido = usuarios.apellido.Trim();
            newuser.rol = usuarios.rol.Trim();
            newuser.login = usuarios.login.Trim();       
            newuser.clave = convertirClave(usuarios.clave.ToString().Trim());

            DBcontext.Usuarios.Add(newuser);
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    public string convertirClave(string cadenaOriginal)
    {
        // Crear una instancia del algoritmo SHA-256
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convertir la cadena original en bytes
            byte[] bytesCadenaOriginal = Encoding.UTF8.GetBytes(cadenaOriginal);

            // Calcular el hash
            byte[] hashBytes = sha256.ComputeHash(bytesCadenaOriginal);

            // Convertir el hash en una cadena hexadecimal
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            string hashCadena = sb.ToString();
            //Console.WriteLine($"Cadena original: {cadenaOriginal}");
            //Console.WriteLine($"Hash SHA-256: {hashCadena}");
            return hashCadena;
        }
    }


    //UPDATE Usuarios BY USER
    public bool EditarUsuario(Usuarios users)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            LoginDBEntities contextDb = new LoginDBEntities();
            Usuarios usrdtl = new Usuarios();
            usrdtl.id_usuario = users.id_usuario;
            usrdtl.nombre = users.nombre.Trim();
            usrdtl.apellido = users.apellido.Trim();
            usrdtl.login = users.login.Trim();
            usrdtl.clave = convertirClave(users.clave.ToString().Trim());
            usrdtl.rol = users.rol.Trim();

            contextDb.Entry(usrdtl).State = EntityState.Modified;
            Retval = contextDb.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception ex)
        {
            //Cuando se tiene validacion de base de datos longitud saca error .Net
            //El campo Name debe ser un tipo de cadena o matriz con una longitud máxima de '10'.
            return bandera;
        }
    }

    //READ ALL USERS
    public List<Usuarios> ConsultarUsuarios()
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Usuarios> userlist = new List<Usuarios>();

        var lstUsr = from k in contextDb.Usuarios select k;

        foreach (var item in lstUsr)
        {
            Usuarios usr = new Usuarios();
            usr.id_usuario = item.id_usuario;
            usr.nombre = item.nombre.Trim();
            usr.apellido = item.apellido.Trim();
            usr.login = item.login.Trim();
            usr.clave = item.clave;
            usr.rol = item.rol.Trim();

            userlist.Add(usr);
        }
        return userlist;
    }

    //READ USER BY ID
    public Usuarios ConsultarUsuarioPorId(int id)
    {
        LoginDBEntities tstDb = new LoginDBEntities();

        var lstUsr = from k in tstDb.Usuarios where k.id_usuario == id select k;
        Usuarios usr = new Usuarios();

        foreach (var item in lstUsr)
        {
            usr.id_usuario = item.id_usuario;
            usr.nombre = item.nombre.Trim();
            usr.apellido = item.apellido.Trim();
            usr.login = item.login.Trim();
            usr.clave = item.clave;
            usr.rol = item.rol.Trim();
        }
        return usr;
    }

    //READ USER BY NAME
    public List<Usuarios> ConsultarUsuariosPorNombre(string name)
    {
        var lstUsr = from k in DBcontext.Usuarios where k.nombre.Contains(name.ToString()) select k;
        List<Usuarios> listUser = new List<Usuarios>();

        foreach (var item in lstUsr)
        {
            Usuarios usr = new Usuarios();
            usr.id_usuario = item.id_usuario;
            usr.nombre = item.nombre.Trim();
            usr.apellido = item.apellido.Trim();
            usr.login = item.login.Trim();
            usr.clave = item.clave;
            usr.rol = item.rol.Trim();
            listUser.Add(usr);
        }
        return listUser;
    }

    //READ USER BY LOGIN
    public List<Usuarios> ConsultarUsuariosPorLogin(string login)
    {
        var lstUsr = from k in DBcontext.Usuarios where k.login.Contains(login.ToString()) select k;
        List<Usuarios> listUser = new List<Usuarios>();

        foreach (var item in lstUsr)
        {
            Usuarios usr = new Usuarios();
            usr.id_usuario = item.id_usuario;
            usr.nombre = item.nombre.Trim();
            usr.apellido = item.apellido.Trim();
            usr.login = item.login.Trim();
            usr.clave = item.clave;
            usr.rol = item.rol.Trim();
            listUser.Add(usr);
        }
        return listUser;
    }

    //DELETE USER BY ID
    public bool EliminarUsuarioPorId(int userId)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            Usuarios Myuser = new Usuarios();
            Myuser.id_usuario = userId;
            DBcontext.Entry(Myuser).State = EntityState.Deleted;
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }
    #endregion

    #region "Trabajos"

    //CREATE Trabajo
    public bool CrearTrabajo(Trabajos trabajo)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            var newTrabajo = new Trabajos();

            newTrabajo.id_trabajo = trabajo.id_trabajo;
            newTrabajo.id_usuario = trabajo.id_usuario;
            newTrabajo.id_materia = trabajo.id_materia;
            newTrabajo.tipo_trabajo = trabajo.tipo_trabajo.Trim();
            newTrabajo.archivo = trabajo.archivo.Trim();
            newTrabajo.fecha_entrega = trabajo.fecha_entrega;

            DBcontext.Trabajos.Add(newTrabajo);
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;

        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //UPDATE Trabajos BY Trabajo
    public bool EditarTrabajo(Trabajos trabajo)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            LoginDBEntities contextDb = new LoginDBEntities();
            Trabajos trabajodtl = new Trabajos();
            trabajodtl.id_trabajo = trabajo.id_trabajo;
            trabajodtl.id_materia = trabajo.id_materia;
            trabajodtl.tipo_trabajo = trabajo.tipo_trabajo.Trim();
            trabajodtl.id_usuario = trabajo.id_usuario;
            trabajodtl.archivo = trabajo.archivo;
            trabajodtl.fecha_entrega = trabajo.fecha_entrega;

            contextDb.Entry(trabajodtl).State = EntityState.Modified;
            Retval = contextDb.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //READ Trabajos por id Materia
    public List<Trabajos> ListarTrabajosPorIdMateria(int id_materia)
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Trabajos> trabajolist = new List<Trabajos>();

        var lstTrabajos = from k in contextDb.Trabajos where k.id_materia == id_materia select k;


        foreach (var item in lstTrabajos)
        {
            Trabajos trabajo = new Trabajos();
            trabajo.id_trabajo = item.id_trabajo;
            trabajo.id_usuario = item.id_usuario;
            trabajo.id_materia = item.id_materia;
            trabajo.tipo_trabajo = item.tipo_trabajo.Trim();
            trabajo.archivo = item.archivo.Trim();
            trabajo.fecha_entrega = item.fecha_entrega;

            trabajolist.Add(trabajo);
        }
        return trabajolist;
    }

    //READ Trabajos por id Materia y id Usuario
    public List<Trabajos> ListarTrabajosPorIdMateriaPorUsuario(int id_materia, int id_usuario)
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Trabajos> trabajolist = new List<Trabajos>();

        var lstTrabajos = from k in contextDb.Trabajos
                          where k.id_materia == id_materia &&
                          k.id_usuario == id_usuario
                          select k;

        foreach (var item in lstTrabajos)
        {
            Trabajos trabajo = new Trabajos();
            trabajo.id_trabajo = item.id_trabajo;
            trabajo.id_usuario = item.id_usuario;
            trabajo.id_materia = item.id_materia;
            trabajo.tipo_trabajo = item.tipo_trabajo.Trim();
            trabajo.archivo = item.archivo.Trim();
            trabajo.fecha_entrega = item.fecha_entrega;

            trabajolist.Add(trabajo);
        }
        return trabajolist;
    }

    //DELETE por Id trabajo.
    public bool EliminarTrabajoPorId(int idTrabajo)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            Trabajos myTrabajo = new Trabajos();
            myTrabajo.id_trabajo = idTrabajo;
            DBcontext.Entry(myTrabajo).State = EntityState.Deleted;
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    #endregion

    #region "Materias"

    //CREATE Materias
    public bool CrearMateria(Materias materia)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            var newMateria = new Materias
            {
                id_materia = materia.id_materia,
                nombre = materia.nombre.Trim(),
                codigo = materia.codigo.Trim(),
                descripcion = materia.descripcion.Trim()
            };

            DBcontext.Materias.Add(newMateria);
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //UPDATE Materias BY Trabajo
    public bool EditarMateria(Materias materia)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            LoginDBEntities contextDb = new LoginDBEntities();
            Materias materiaObj = new Materias();
            materiaObj.id_materia = materia.id_materia;
            materiaObj.nombre = materia.nombre.Trim();
            materiaObj.codigo = materia.codigo.Trim();
            materiaObj.descripcion = materia.descripcion.Trim();

            contextDb.Entry(materia).State = EntityState.Modified;
            Retval = contextDb.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //READ Consultar Materias
    public List<Materias> ListarMaterias()
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Materias> materialist = new List<Materias>();

        var lstMaterias = from k in contextDb.Materias select k;

        foreach (var item in lstMaterias)
        {
            Materias materia = new Materias();
            materia.id_materia = item.id_materia;
            materia.nombre = item.nombre.Trim();
            materia.codigo = item.codigo.Trim();
            materia.descripcion = item.descripcion.Trim();

            materialist.Add(materia);
        }
        return materialist;
    }

    //READ Consultar Materias por Id materia
    public List<Materias> ListarMateriasPorId(int idMateria)
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Materias> materialist = new List<Materias>();

        var lstMaterias = from k in contextDb.Materias
                          where k.id_materia == idMateria
                          select k;

        foreach (var item in lstMaterias)
        {
            Materias materia = new Materias();
            materia.id_materia = item.id_materia;
            materia.nombre = item.nombre.Trim();
            materia.codigo = item.codigo.Trim();
            materia.descripcion = item.descripcion.Trim();

            materialist.Add(materia);
        }
        return materialist;
    }

    //DELETE Materia por id Materia
    public bool EliminarMateriaPorId(int idMateria)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            Materias myMateria = new Materias();
            myMateria.id_materia = idMateria;
            DBcontext.Entry(myMateria).State = EntityState.Deleted;
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    #endregion

    #region "Asistencias"
    //CREATE Asistencias
    public bool CrearAsistencia(Asistencias asistencia)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            var newAsistencia = new Asistencias
            {
                id_asistencia = asistencia.id_asistencia,
                id_usuario = asistencia.id_usuario,
                id_materia = asistencia.id_materia,
                fecha = asistencia.fecha,
                asistio = asistencia.asistio
            };

            DBcontext.Asistencias.Add(newAsistencia);
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }
    //UPDATE Asistencias BY id
    public bool EditarAsistencia(Asistencias asistencia)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            LoginDBEntities contextDb = new LoginDBEntities();
            Asistencias asistenciaObj = new Asistencias();
            asistenciaObj.id_asistencia = asistencia.id_asistencia;
            asistenciaObj.id_usuario = asistencia.id_usuario;
            asistenciaObj.id_materia = asistencia.id_materia;
            asistenciaObj.fecha = asistencia.fecha;
            asistenciaObj.asistio = asistencia.asistio;

            contextDb.Entry(asistencia).State = EntityState.Modified;
            Retval = contextDb.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //READ Consultar Asitencias
    public List<Asistencias> ListarAsistencias()
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Asistencias> asistencialist = new List<Asistencias>();

        var lstAsistencias = from k in contextDb.Asistencias select k;

        foreach (var item in lstAsistencias)
        {
            Asistencias asistencia = new Asistencias();
            asistencia.id_asistencia = item.id_asistencia;
            asistencia.id_usuario = item.id_usuario;
            asistencia.id_materia = item.id_materia;
            asistencia.fecha = item.fecha;
            asistencia.asistio = item.asistio;

            asistencialist.Add(asistencia);
        }
        return asistencialist;
    }

    //READ Consultar Asistencias por Id materia
    public List<Asistencias> ListarAsistenciasPorIdMateria(int idMateria)
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Asistencias> asistencialist = new List<Asistencias>();

        var lstAsistencias = from k in contextDb.Asistencias
                             where k.id_materia == idMateria
                             select k;

        foreach (var item in lstAsistencias)
        {
            Asistencias asistencia = new Asistencias();
            asistencia.id_asistencia = item.id_asistencia;
            asistencia.id_usuario = item.id_usuario;
            asistencia.id_materia = item.id_materia;
            asistencia.fecha = item.fecha;
            asistencia.asistio = item.asistio;

            asistencialist.Add(asistencia);
        }
        return asistencialist;
    }

    //DELETE Asistencia por id 
    public bool EliminarAsistenciaPorId(int idAsistencia)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            Asistencias asistencia = new Asistencias();
            asistencia.id_asistencia = idAsistencia;
            DBcontext.Entry(asistencia).State = EntityState.Deleted;
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }
    #endregion

    #region "Calificaciones"
    //CREATE Calificacion
    public bool CrearCalificaciones(Calificaciones calificaciones)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            var newCalificacion = new Calificaciones
            {
                id_calificacion = calificaciones.id_calificacion,
                id_usuario = calificaciones.id_usuario,
                id_materia = calificaciones.id_materia,
                tipo_actividad = calificaciones.tipo_actividad,
                calificacion = calificaciones.calificacion
            };

            DBcontext.Calificaciones.Add(newCalificacion);
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }
    //UPDATE Calificaciones BY id
    public bool EditarCalificacion(Calificaciones calificacion)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            LoginDBEntities contextDb = new LoginDBEntities();
            Calificaciones calificacionObj = new Calificaciones();
            calificacionObj.id_calificacion = calificacion.id_calificacion;
            calificacionObj.id_usuario = calificacion.id_usuario;
            calificacionObj.id_materia = calificacion.id_materia;
            calificacionObj.tipo_actividad = calificacion.tipo_actividad;
            calificacionObj.calificacion = calificacion.calificacion;

            contextDb.Entry(calificacion).State = EntityState.Modified;
            Retval = contextDb.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //READ Consultar Calificaciones
    public List<Calificaciones> ListarCalificaciones()
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Calificaciones> calificacionlist = new List<Calificaciones>();

        var lstCalificacion = from k in contextDb.Calificaciones select k;

        foreach (var item in lstCalificacion)
        {
            Calificaciones calificacion = new Calificaciones();
            calificacion.id_calificacion = item.id_calificacion;
            calificacion.id_usuario = item.id_usuario;
            calificacion.id_materia = item.id_materia;
            calificacion.tipo_actividad = item.tipo_actividad;
            calificacion.calificacion = item.calificacion;

            calificacionlist.Add(calificacion);
        }
        return calificacionlist;
    }

    //READ Consultar Calificaciones por Id usuario
    public List<Calificaciones> ListarCalificacionesPorIdUsuario(int idUsuario)
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Calificaciones> califiacionlist = new List<Calificaciones>();

        var lstCalificacion = from k in contextDb.Calificaciones
                             where k.id_usuario == idUsuario
                             select k;

        foreach (var item in lstCalificacion)
        {
            Calificaciones calificacion = new Calificaciones();
            calificacion.id_calificacion = item.id_calificacion;
            calificacion.id_usuario = item.id_usuario;
            calificacion.id_materia = item.id_materia;
            calificacion.tipo_actividad = item.tipo_actividad;
            calificacion.calificacion = item.calificacion;

            califiacionlist.Add(calificacion);
        }
        return califiacionlist;
    }

    //DELETE Asistencia por id 
    public bool EliminarCalificacionPorId(int idCalificacion)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            Calificaciones calificacion = new Calificaciones();
            calificacion.id_calificacion = idCalificacion;
            DBcontext.Entry(calificacion).State = EntityState.Deleted;
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }
    #endregion

    #region "Materias_estudiantes"
    //CREATE Materias estudiantes
    public bool CrearMateriasEstudiantes(Materias_estudiantes materiaEstudiante)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            var newMateriasEstudiantes = new Materias_estudiantes
            {
                id_materia_estudiante = materiaEstudiante.id_materia_estudiante,
                id_materia = materiaEstudiante.id_materia,
                id_usuario = materiaEstudiante.id_usuario
            };

            DBcontext.Materias_estudiantes.Add(newMateriasEstudiantes);
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //UPDATE Materias estudiantes BY id
    public bool EditarMateriaEstudiante(Materias_estudiantes materiaEstudiante)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            LoginDBEntities contextDb = new LoginDBEntities();
            Materias_estudiantes materiasEstudiantesObj = new Materias_estudiantes();
            materiasEstudiantesObj.id_materia_estudiante = materiaEstudiante.id_materia_estudiante;
            materiasEstudiantesObj.id_materia = materiaEstudiante.id_materia;
            materiasEstudiantesObj.id_usuario = materiaEstudiante.id_usuario;

            contextDb.Entry(materiaEstudiante).State = EntityState.Modified;
            Retval = contextDb.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //READ Consultar MateriasEstudiantes
    public List<Materias_estudiantes> ListarMateriasEstudiantes()
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Materias_estudiantes> materiaEstudiantelist = new List<Materias_estudiantes>();

        var lstMateriasEstudiantes = from k in contextDb.Materias_estudiantes select k;

        foreach (var item in lstMateriasEstudiantes)
        {
            Materias_estudiantes materiaEstudiantes = new Materias_estudiantes();
            materiaEstudiantes.id_materia_estudiante = item.id_materia_estudiante;
            materiaEstudiantes.id_materia = item.id_materia;
            materiaEstudiantes.id_usuario = item.id_usuario;


            materiaEstudiantelist.Add(materiaEstudiantes);
        }
        return materiaEstudiantelist;
    }

    //READ Consultar MateriasEstudiantes por id usuario
    public List<Materias_estudiantes> ListarMateriasEstudiantesPorId(int idUsuario)
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Materias_estudiantes> estudiantesMaterialist = new List<Materias_estudiantes>();

        var lstMateriasEstudiantes = from k in contextDb.Materias_estudiantes
                          where k.id_usuario == idUsuario
                          select k;

        foreach (var item in lstMateriasEstudiantes)
        {
            Materias_estudiantes materiaEstudiantes = new Materias_estudiantes();
            materiaEstudiantes.id_materia_estudiante = item.id_materia_estudiante;
            materiaEstudiantes.id_materia = item.id_materia;
            materiaEstudiantes.id_usuario = item.id_usuario;

            estudiantesMaterialist.Add(materiaEstudiantes);
        }
        return estudiantesMaterialist;
    }

    //DELETE Materia por id Materia
    public bool EliminarMateriaEstudiantesPorId(int idMateriaEstudiante)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            Materias_estudiantes materiaEstudiantes = new Materias_estudiantes();
            materiaEstudiantes.id_materia_estudiante = idMateriaEstudiante;
            DBcontext.Entry(materiaEstudiantes).State = EntityState.Deleted;
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }
    #endregion


    #region "Materias_docentes"
    //CREATE Materias docentes
    public bool CrearMateriasDocentes(Materias_docentes materiaDocente)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            var newMateriasDocentes = new Materias_docentes
            {
                id_materia_docente = materiaDocente.id_materia_docente,
                id_materia = materiaDocente.id_materia,
                id_usuario = materiaDocente.id_usuario
            };

            DBcontext.Materias_docentes.Add(newMateriasDocentes);
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //UPDATE Materias docentes BY id
    public bool EditarMateriaDocente(Materias_docentes materiaDocente)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            LoginDBEntities contextDb = new LoginDBEntities();
            Materias_docentes materiasDocentesObj = new Materias_docentes();
            materiasDocentesObj.id_materia_docente = materiaDocente.id_materia_docente;
            materiasDocentesObj.id_materia = materiaDocente.id_materia;
            materiasDocentesObj.id_usuario = materiaDocente.id_usuario;

            contextDb.Entry(materiaDocente).State = EntityState.Modified;
            Retval = contextDb.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //READ Consultar MateriasEstudiantes
    public List<Materias_docentes> ListarMateriasDocentes()
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Materias_docentes> materiaDocenteslist = new List<Materias_docentes>();

        var lstMateriasDocentes = from k in contextDb.Materias_docentes select k;

        foreach (var item in lstMateriasDocentes)
        {
            Materias_docentes materiaDocentes = new Materias_docentes();
            materiaDocentes.id_materia_docente = item.id_materia_docente;
            materiaDocentes.id_materia = item.id_materia;
            materiaDocentes.id_usuario = item.id_usuario;


            materiaDocenteslist.Add(materiaDocentes);
        }
        return materiaDocenteslist;
    }

    //READ Consultar MateriasDocentes por id usuario
    public List<Materias_docentes> ListarMateriasDocentesPorId(int idUsuario)
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Materias_docentes> docentesMaterialist = new List<Materias_docentes>();

        var lstMateriasDocentes = from k in contextDb.Materias_docentes
                                     where k.id_usuario == idUsuario
                                     select k;

        foreach (var item in lstMateriasDocentes)
        {
            Materias_docentes materiaDocentes = new Materias_docentes();
            materiaDocentes.id_materia_docente = item.id_materia_docente;
            materiaDocentes.id_materia = item.id_materia;
            materiaDocentes.id_usuario = item.id_usuario;

            docentesMaterialist.Add(materiaDocentes);
        }
        return docentesMaterialist;
    }

    //DELETE Materia por id Materia
    public bool EliminarMateriaDocentesPorId(int idMateriaDocente)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            Materias_docentes materiaDocentes = new Materias_docentes();
            materiaDocentes.id_materia_docente = idMateriaDocente;
            DBcontext.Entry(materiaDocentes).State = EntityState.Deleted;
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }
    #endregion
}
