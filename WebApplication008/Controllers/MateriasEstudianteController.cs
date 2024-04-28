using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;
using WebApplication008.WCFServicioDatos;

namespace WebApplication008.Controllers
{
    public class MateriasEstudianteController : Controller
    {
        // GET: MateriasEstudiante
        public ActionResult Index()
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            List<Materias_estudiantesModel> lstRecord = new List<Materias_estudiantesModel>();
            var myListaMaterias = myCliente.ListarMateriasEstudiantes();

            //var listaMaterias = myCliente.ListarMateriaEstudiante();

            var myMaterias = myCliente.ListarMaterias();
            var myUsuarios = myCliente.ConsultarUsuariosPorRol("Estudiante");

            //Muestro los roles
            List<SelectListItem> roles = new List<SelectListItem>
            {
                new SelectListItem { Text = "Docente", Value = "1" },
                new SelectListItem { Text = "Estudiante", Value = "2" }
            };
            
            ViewBag.Rol = roles;


            //Muestro los roles
            List<SelectListItem> Estudiantes = new List<SelectListItem>();

            //Lleno el SelectListItem
            foreach (var itemUsu in myUsuarios)
            {
                Estudiantes.Add(new SelectListItem
                {
                    Text = itemUsu.nombre,
                    Value = itemUsu.id_usuario.ToString()
                });
            }

            ViewBag.Estudiantes = Estudiantes;


            //creo el list de materias
            List<SelectListItem> MateriasEstudiantes = new List<SelectListItem>();

            foreach (var item in myMaterias)
            {
                MateriasEstudiantes.Add(new SelectListItem
                {
                    Text = item.nombre,
                    Value = item.id_materia.ToString()
                });
            }

            ViewBag.Materias = MateriasEstudiantes;


            foreach (var item in myListaMaterias)
            {
                Materias_estudiantesModel materia = new Materias_estudiantesModel();

                materia.Id_materia_estudiante = item.id_materia_estudiante;
                materia.Id_Usuario = item.id_usuario;
                materia.Id_materia = item.id_materia;

                lstRecord.Add(materia);
            }

            

            //Materias_estudiantesModel materia = new Materias_estudiantesModel();
            //materia.Id_materia_estudiante = 7;
            //materia.Id_Usuario = 4;
            //materia.Id_materia = 2;
            //lstRecord.Add(materia);            

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
                List<WCFServicioDatos.Usuarios> lstUsuarios = new List<WCFServicioDatos.Usuarios>();
                List<UserModel> RegFiltrado = new List<UserModel>();

                //lstUsuarios = myCliente.ConsultarUsuariosPorNombre(inputBuscar).ToList();
                //foreach (var item in lstUsuarios)
                //{
                //    UserModel usr = new UserModel();

                //    usr.Id = item.Id;
                //    usr.UserName = item.UserName;
                //    usr.Password = item.Password;
                //    usr.Nombre = item.Nombre;
                //    usr.Apellido = item.Apellido;
                //    usr.Email = item.Email;

                //    RegFiltrado.Add(usr);
                //}
                ////var RegFiltrado = (from f in usuario
                ////                   where f.Nombre.StartsWith(inpBuscar) ||
                ////                    f.Nombre.Contains(inpBuscar) ||
                ////                   orderby f.FecVisita descending
                ////                   select f).Take(15);                
                return View(RegFiltrado.ToList());
            }
            else
            {
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
                    usr.Password = item.clave;

                    lstRecord.Add(usr);
                }

                return View(lstRecord.ToList());
            }
        }

        // GET: MateriasEstudiante/Details/5
        public ActionResult Details(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objMateria = myCliente.ListarMateriasEstudiantesPorId(id);

            var MyMateria = new Materias_estudiantesModel();

            MyMateria.Id_materia_estudiante = id;

            MyMateria.Id_Usuario = objMateria[0].id_usuario;

            MyMateria.Id_materia = objMateria[0].id_materia;

            if (Session["UserName"] != null)
            {
                return View(MyMateria);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: MateriasEstudiante/Create
        public ActionResult Create()
        {
            return View(new Materias_estudiantesModel());
        }

        // POST: MateriasEstudiante/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Materias_estudiantesModel objMateria_est)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

                try
                {
                    WCFServicioDatos.Materias_estudiantes materiaEstudianete = new WCFServicioDatos.Materias_estudiantes();
                    //TblUsuario.Id = 0;
                    materiaEstudianete.id_materia_estudiante = objMateria_est.Id_materia_estudiante;
                    materiaEstudianete.id_usuario = objMateria_est.Id_Usuario;
                    materiaEstudianete.id_materia = objMateria_est.Id_materia;
                    

                    bool Resval = myCliente.CrearMateriasEstudiantes(materiaEstudianete);

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
            catch
            {
                return View();
            }
        }

        // GET: MateriasEstudiante/Edit/5
        public ActionResult Edit(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myMateria = myCliente.ListarMateriasEstudiantesPorId(id).ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    var materia = new Materias_estudiantesModel();

                    materia.Id_materia_estudiante = myMateria[0].id_materia_estudiante;
                    materia.Id_materia = myMateria[0].id_materia;
                    materia.Id_Usuario = myMateria[0].id_usuario;                    

                    if (Session["UserName"] != null)
                    {
                        return View(materia);
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

        // POST: MateriasEstudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(Materias_estudiantesModel objAsistencia, FormCollection collection)
        {
            WCFServicioDatos.ServiceClient myMateriaEsutiante = new WCFServicioDatos.ServiceClient();
            bool resVal = false;
            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.Materias_estudiantes materiaEstuadiante = new WCFServicioDatos.Materias_estudiantes();

                    materiaEstuadiante.id_materia_estudiante = objAsistencia.Id_materia_estudiante;
                    materiaEstuadiante.id_materia = objAsistencia.Id_materia;
                    materiaEstuadiante.id_usuario = objAsistencia.Id_Usuario;


                    resVal = myMateriaEsutiante.EditarMateriaEstudiante(materiaEstuadiante); //actualiza objeto Asitencias
                    return RedirectToAction("Index");
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

        // GET: MateriasEstudiante/Delete/5
        public ActionResult Delete(int id)
        {
            WCFServicioDatos.ServiceClient myMateriaEsutiantes = new WCFServicioDatos.ServiceClient();
            var myMateriaEsutiante = myMateriaEsutiantes.ListarMateriasEstudiantesPorId(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var mEstudiante = new Materias_estudiantesModel();
                    mEstudiante.Id_materia_estudiante = myMateriaEsutiante[0].id_materia_estudiante;
                    mEstudiante.Id_materia = myMateriaEsutiante[0].id_materia;
                    mEstudiante.Id_Usuario = myMateriaEsutiante[0].id_usuario;


                    if (Session["UserName"] != null)
                    {
                        return View(mEstudiante);
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

        // POST: MateriasEstudiante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                WCFServicioDatos.ServiceClient myMateriaEsutiantes = new WCFServicioDatos.ServiceClient();
                bool Rev = myMateriaEsutiantes.EliminarMateriaEstudiantesPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
