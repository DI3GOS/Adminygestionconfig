using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;

namespace WebApplication008.Controllers
{
    public class MateriasProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Index()
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            List<ProfesorModel> lstRecord = new List<ProfesorModel>();
            var myListaMaterias = myCliente.ListarMateriasDocentes();

            foreach (var item in myListaMaterias)
            {
                ProfesorModel profesor = new ProfesorModel();

                profesor.id_materia_docente = item.id_materia_docente;
                profesor.id_materia = item.id_materia;
                profesor.id_usuario = item.id_usuario;

                lstRecord.Add(profesor);
            }

            if (Session["UserName"] != null)
            {
                return View(lstRecord.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Profesor/Details/5
        public ActionResult Details(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objProfesor= myCliente.ListarMateriasDocentesPorIdMateriaDocente(id);

            var MyProfesor = new ProfesorModel();

            MyProfesor.id_materia_docente = id;

            MyProfesor.id_materia = objProfesor[0].id_materia;

            MyProfesor.id_usuario = objProfesor[0].id_usuario;


            if (Session["UserName"] != null)
            {
                return View(MyProfesor);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Profesor/Create
        public ActionResult Create()
        {
            return View(new ProfesorModel());
        }

        // POST: Profesor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, ProfesorModel objProfesor)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

                try
                {
                    WCFServicioDatos.Materias_docentes TblMateria = new WCFServicioDatos.Materias_docentes();
                    //TblUsuario.Id = 0;
                    TblMateria.id_usuario = objProfesor.id_usuario;
                    TblMateria.id_materia_docente = objProfesor.id_materia_docente;
                    TblMateria.id_materia = objProfesor.id_materia;

                    bool Resval = myCliente.CrearMateriasDocentes(TblMateria);

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

        // GET: Profesor/Edit/5
        public ActionResult Edit(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myMateria = myCliente.ListarMateriasDocentesPorIdMateriaDocente(id).ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    var profesor = new ProfesorModel();

                    profesor.id_materia_docente = myMateria[0].id_materia_docente;
                    profesor.id_usuario = myMateria[0].id_usuario;
                    profesor.id_materia = myMateria[0].id_materia;

                    if (Session["UserName"] != null)
                    {
                        return View(profesor);
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

        // POST: Profesor/Edit/5
        [HttpPost]
        public ActionResult Edit(ProfesorModel objProfesor, FormCollection collection)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            bool resVal = false;
            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.Materias_docentes materiasDocentes = new WCFServicioDatos.Materias_docentes();

                    materiasDocentes.id_materia_docente = objProfesor.id_materia_docente;
                    materiasDocentes.id_materia = objProfesor.id_materia;
                    materiasDocentes.id_usuario = objProfesor.id_usuario;

                    resVal = myCliente.EditarMateriaDocente(materiasDocentes); //actualiza objeto Materias
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

        // GET: Profesor/Delete/5
        public ActionResult Delete(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myMateria = myCliente.ListarMateriasDocentesPorIdMateriaDocente(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var materia = new ProfesorModel();
                    materia.id_materia_docente = myMateria[0].id_materia_docente;
                    materia.id_materia = myMateria[0].id_materia;
                    materia.id_usuario = myMateria[0].id_usuario;

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

        // POST: Profesor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
                bool Rev = myCliente.EliminarMateriaDocentesPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
