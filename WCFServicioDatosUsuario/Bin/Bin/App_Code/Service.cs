using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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
}
