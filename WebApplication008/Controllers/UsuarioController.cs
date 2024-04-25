using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;

namespace WebApplication008.Controllers
{
    public class UsuarioController : Controller
    {
        //private IUsuario IUsu;
        //public UsuarioController()
        //{
        //    this.IUsu = new UsuarioRepository(new LoginDBEntities1());
        //}

        // GET: Usuario                
        public ActionResult Index()
        {
            //var list = IPaySheet.GetUsers().ToList();
            //return View(list);
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            List<UserModel> lstRecord = new List<UserModel>();
            var myListaUsers = myCliente.ListarTodosUsuarios();

            foreach (var item in myListaUsers)
            {
                UserModel usr = new UserModel();

                usr.Id = item.Id;                
                usr.UserName = item.UserName;                
                usr.Password = item.Password;
                usr.Nombre = item.Nombre;
                usr.Apellido = item.Apellido;
                usr.Email = item.Email;

                lstRecord.Add(usr);
            }

            //test de metodos usuarios

            if (Session["UserName"] != null)
            {
                return View(lstRecord.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }            
        }

        [HttpPost]
        public ActionResult Index(string inputBuscar)  //debe tener el nombre del input text igual
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

            if (inputBuscar.Length > 0)
            {   
                List<WCFServicioDatos.Usuario> lstUsuarios = new List<WCFServicioDatos.Usuario>();
                List<UserModel> RegFiltrado = new List<UserModel>();

                lstUsuarios = myCliente.ObtenerUsuariosPorNombre(inputBuscar).ToList();
                foreach (var item in lstUsuarios)
                {
                    UserModel usr = new UserModel();

                    usr.Id = item.Id;
                    usr.UserName = item.UserName;
                    usr.Password = item.Password;
                    usr.Nombre = item.Nombre;
                    usr.Apellido = item.Apellido;
                    usr.Email = item.Email;

                    RegFiltrado.Add(usr);
                }
                //var RegFiltrado = (from f in usuario
                //                   where f.Nombre.StartsWith(inpBuscar) ||
                //                    f.Nombre.Contains(inpBuscar) ||
                //                   orderby f.FecVisita descending
                //                   select f).Take(15);                
                return View(RegFiltrado.ToList());
            }
            else
            {   
                List<UserModel> lstRecord = new List<UserModel>();
                var myListaUsers = myCliente.ListarTodosUsuarios();

                foreach (var item in myListaUsers)
                {
                    UserModel usr = new UserModel();

                    usr.Id = item.Id;
                    usr.UserName = item.UserName;
                    usr.Password = item.Password;
                    usr.Nombre = item.Nombre;
                    usr.Apellido = item.Apellido;
                    usr.Email = item.Email;

                    lstRecord.Add(usr);
                }

                return View(lstRecord.ToList()); //devuelvo la lista de todos
            }
        }


        // GET: Usuario/Details/5        
        public ActionResult Details(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objUsu = myCliente.ObtenerUsuarioPorId(id);

            //var objUsu = IUsu.GetUsuarioByID(id);
            var MyUsuario = new WCFServicioDatos.Usuario();

            MyUsuario.Id = id;

            MyUsuario.Nombre = objUsu.Nombre;

            MyUsuario.Apellido = objUsu.Apellido;

            MyUsuario.Password = objUsu.Password;

            MyUsuario.Email = objUsu.Email;

            MyUsuario.UserName = objUsu.UserName;

            if (Session["UserName"] != null)
            {
                return View(MyUsuario);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View(new UserModel()); //Se actualiza a UserModel
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, UserModel objusuario)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

            try
            {
                WCFServicioDatos.Usuario TblUsuario = new WCFServicioDatos.Usuario();
                //TblUsuario.Id = 0;
                TblUsuario.UserName = objusuario.UserName;
                TblUsuario.Nombre = objusuario.Nombre;
                TblUsuario.Apellido = objusuario.Apellido;
                TblUsuario.Password = objusuario.Password;
                TblUsuario.Email = objusuario.Email;

                int Resval = myCliente.InsertarUsuario(TblUsuario);

                if (Session["UserName"] != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }                
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myUsuario = myCliente.ObtenerUsuarioPorId(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var user = new UserModel();

                    user.Id = myUsuario.Id;
                    user.UserName = myUsuario.UserName;
                    user.Password = myUsuario.Password;
                    user.Nombre = myUsuario.Nombre;
                    user.Apellido = myUsuario.Apellido;
                    user.Email = myUsuario.Email;


                    if (Session["UserName"] != null)
                    {
                        return View(user);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");
                    }                    
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //var objusu = IUsu.GetUsuarioByID(id); // getting records by id GetEmployeeByID(ID)
            //var Usuario = new Usuario();
            //Usuario.Id = id;
            //Usuario.Nombre = objusu.Nombre;
            //Usuario.UserName = objusu.UserName;
            //Usuario.Apellido = objusu.Apellido;
            //Usuario.Password  = objusu.Password;
            //Usuario.Email = objusu.Email;
            //return View(Usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UserModel objusu, FormCollection collection)
        {

            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            int resVal = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.Usuario user = new WCFServicioDatos.Usuario();

                    user.Id = objusu.Id;
                    user.UserName = objusu.UserName;
                    user.Password = objusu.Password;
                    user.Nombre = objusu.Nombre;
                    user.Apellido = objusu.Apellido;
                    user.Email = objusu.Email;

                    resVal = myCliente.ModificarUsuario(user); //actualiza el usuario
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }

            catch
            {
                return View();
            }            
        }

        // GET: Employee/Delete/5
        [HttpGet]        
        public ActionResult Delete(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myUsuario = myCliente.ObtenerUsuarioPorId(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var user = new UserModel();
                    user.Id = myUsuario.Id;
                    user.UserName = myUsuario.UserName;
                    user.Password = myUsuario.Password;
                    user.Nombre = myUsuario.Nombre;
                    user.Apellido = myUsuario.Apellido;
                    user.Email = myUsuario.Email;

                    if (Session["UserName"] != null)
                    {
                        return View(user);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");
                    }                    
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }

            //var objusu = IUsu.GetUsuarioByID(id); // calling GetEmployeeByID method of EmployeeRepository
            //return View(objusu);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
                int Rev = myCliente.BorrarUsuarioPorId(id);
                //IUsu.DeleteUsuario(id); // calling DeleteUsuario method of UsuarioRepository
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
