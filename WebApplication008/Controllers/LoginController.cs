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
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel login)
        {
            try
            {
                //23-04-2024 Johny C. Codigo OK con modelo UserModel
                //if (ModelState.IsValid)
                //{
                //    WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
                //    List<WCFServicioDatos.Usuario> usuario = new List<WCFServicioDatos.Usuario>();

                //    usuario = myCliente.ListarTodosUsuarios().ToList();

                //    var user = (from userlist in usuario.ToList()
                //                where userlist.UserName.Trim() == login.UserName && userlist.Password.Trim() == login.Password
                //                select new
                //                {
                //                    userlist.Id,
                //                    userlist.UserName
                //                }).ToList();
                //    if (user.FirstOrDefault() != null)
                //    {
                //        Session["UserName"] = user.FirstOrDefault().UserName.Trim();
                //        Session["UserID"] = user.FirstOrDefault().Id;
                //        return Redirect("/Home/Index");
                //    }
                //    else
                //    {
                //        //se deben de llamar igual
                //        ModelState.AddModelError("mensajeErrorName", "Credenciales Invalidas");
                //    }
                //}
                //return View(login);

                //23-04-2024 Johny C. Codigo de prueba con modelo UsuariosModel
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
                    List<WCFServicioDatos.Usuarios> usuario = new List<WCFServicioDatos.Usuarios>();

                    usuario = myCliente.ConsultarUsuarios().ToList();

                    var user = (from userlist in usuario.ToList()
                                where userlist.login.Trim() == login.UserName && userlist.clave == convertirClave(login.Password.Trim())
                                select new
                                {
                                    userlist.id_usuario,
                                    userlist.login,
                                    userlist.rol
                                }).ToList();
                    if (user.FirstOrDefault() != null)
                    {
                        Session["UserName"] = user.FirstOrDefault().login.Trim();
                        Session["UserID"] = user.FirstOrDefault().id_usuario;
                        Session["UserRol"] = user.FirstOrDefault().rol;
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        //se deben de llamar igual
                        ModelState.AddModelError("mensajeErrorName", "Credenciales Invalidas");
                    }
                }
                return View(login);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("mensajeErrorName", "Error con el WebService");
                return View(login);                
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
    }
}