using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;

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

            var listaMaterias = myCliente.ListarMateriaEstudiante();

            var myMaterias = myCliente.ListarMaterias();
            var myUsuarios = myCliente.ConsultarUsuarios();

            //Muestro los roles
            List<SelectListItem> roles = new List<SelectListItem>
            {
                new SelectListItem { Text = "Administrador", Value = "Administrador" },
                new SelectListItem { Text = "Docente", Value = "Docente" },
                new SelectListItem { Text = "Estudiante", Value = "Estudiante" }
            };            
            ViewData["Rol"] = roles;

            //Muestro los roles
            List<SelectListItem> Estudiantes = new List<SelectListItem>();

            //Lleno el SelectListItem
            foreach (var itemUsu in myUsuarios)
            {
                Estudiantes.Add(new SelectListItem
                {
                    Text = itemUsu.id_usuario.ToString(),
                    Value = itemUsu.nombre
                });
            }

            ViewData["Estudiantes"] = Estudiantes;

            //foreach (var item in myListaMaterias)
            //{
            //    MateriaEstudianteModel materia = new MateriaEstudianteModel();

            //    materia.Id = item.Id;
            //    materia.Nombre = item.Nombre.Trim();
            //    materia.Apellido = item.Apellido.Trim();
            //    materia.Rol = item.Rol;
            //    materia.Materia = item.Materia;

            //    lstRecord.Add(materia);
            //}
                        
            Materias_estudiantesModel materia = new Materias_estudiantesModel();
            materia.Id_materia_estudiante = 7;
            materia.Id_Usuario = 4;
            materia.Id_materia = 2;

            lstRecord.Add(materia);            

            if (Session["UserName"] != null)
            {
                return View(lstRecord.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: MateriasEstudiante/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MateriasEstudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MateriasEstudiante/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MateriasEstudiante/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
