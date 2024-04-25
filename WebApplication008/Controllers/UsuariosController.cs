using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;

namespace WebApplication008.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            List<UsuariosModel> lstRecord = new List<UsuariosModel>();
            var myListaUsers = myCliente.ConsultarUsuarios();

            foreach (var item in myListaUsers)
            {
                UsuariosModel usr = new UsuariosModel();

                usr.Id_usuario = item.id_usuario;
                usr.Nombre = item.nombre;
                usr.Apellido = item.apellido;
                usr.Rol = item.rol;
                usr.Login = item.login;
                usr.Password = item.clave.ToString();
                lstRecord.Add(usr);
            }

            //validar si esta logeado
            if (Session["UserName"] != null)
            {
                return View(lstRecord.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objUsu = myCliente.ConsultarUsuarioPorId(id);

            UsuariosModel MyUsuario = new UsuariosModel();

            //var objUsu = IUsu.GetUsuarioByID(id);
            //var MyUsuario = new WCFServicioDatos.Usuarios();

            MyUsuario.Id_usuario = id;
            MyUsuario.Nombre = objUsu.nombre;
            MyUsuario.Apellido = objUsu.apellido;
            MyUsuario.Rol = objUsu.rol;
            MyUsuario.Login = objUsu.login;
            MyUsuario.Password = objUsu.clave;

            if (Session["UserName"] != null)
            {
                return View(MyUsuario);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View(new UsuariosModel());
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, UsuariosModel objUsuario)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

            try
            {
                WCFServicioDatos.Usuarios TblUsuarios = new WCFServicioDatos.Usuarios();
                //TblUsuario.Id = 0;                
                TblUsuarios.nombre = objUsuario.Nombre;
                TblUsuarios.apellido = objUsuario.Apellido;
                TblUsuarios.rol = objUsuario.Rol;
                TblUsuarios.login = objUsuario.Login;                
                //Se encripta la clave                 
                TblUsuarios.clave = objUsuario.Password.ToString();

                bool Resval = myCliente.CrearUsuario(TblUsuarios);

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

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myUsuario = myCliente.ConsultarUsuarioPorId(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var user = new UsuariosModel();

                    user.Id_usuario = myUsuario.id_usuario;
                    user.Nombre = myUsuario.nombre;
                    user.Apellido = myUsuario.apellido;
                    user.Rol = myUsuario.rol;
                    user.Login = myUsuario.login;
                    user.Password = myUsuario.clave;

                    List<SelectListItem> items = new List<SelectListItem>();
                    if(user.Rol == "Administrador"){
                        items.Add(new SelectListItem { Text = "Administrador", Value = "Administrador", Selected = true });
                        items.Add(new SelectListItem { Text = "Docente", Value = "Docente" });
                        items.Add(new SelectListItem { Text = "Estudiante", Value = "Estudiante" });
                    }
                    if (user.Rol == "Docente")
                    {
                        items.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
                        items.Add(new SelectListItem { Text = "Docente", Value = "Docente", Selected = true });
                        items.Add(new SelectListItem { Text = "Estudiante", Value = "Estudiante" });
                    }

                    if (user.Rol == "Estudiante")
                    {
                        items.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
                        items.Add(new SelectListItem { Text = "Docente", Value = "Docente" });
                        items.Add(new SelectListItem { Text = "Estudiante", Value = "Estudiante", Selected = true });
                    }

                    ViewData["Rol"] = items;

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
        }
    
        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuariosModel objusu, FormCollection collection)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            bool resVal = false;
            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.Usuarios user = new WCFServicioDatos.Usuarios();

                    user.id_usuario = objusu.Id_usuario;
                    user.nombre = objusu.Nombre;
                    user.apellido = objusu.Apellido;
                    user.rol = objusu.Rol;
                    user.login = objusu.Login;
                    user.clave = objusu.Password;

                    resVal = myCliente.EditarUsuario(user);
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

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myUsuario = myCliente.ConsultarUsuarioPorId(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var user = new UsuariosModel();
                    user.Id_usuario = myUsuario.id_usuario;
                    user.Nombre = myUsuario.nombre;
                    user.Apellido = myUsuario.apellido;
                    user.Login = myUsuario.login;
                    user.Password = myUsuario.clave;
                    user.Rol = myUsuario.rol;

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
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
                bool Rev = myCliente.EliminarUsuarioPorId(id);                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
