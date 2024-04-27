using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;
using WebApplication008.WCFServicioDatos;

namespace WebApplication008.Controllers
{
    public class CalificacionController : Controller
    {
        // GET: Calificacion
        public ActionResult Index()
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            List<CalificacionesModel> lstRecord = new List<CalificacionesModel>();

            try
            {
                var myListaCalificaciones = myCliente.ListarCalificaciones();

                foreach (var item in myListaCalificaciones)
                {
                    CalificacionesModel calificacion = new CalificacionesModel();

                    calificacion.Id_calificacion = item.id_calificacion;
                    calificacion.Id_usuario = item.id_usuario;
                    calificacion.Id_materia = item.id_materia;
                    calificacion.calificacion = item.calificacion.Value;
                    calificacion.tipo_actividad = item.tipo_actividad;

                    lstRecord.Add(calificacion);
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
            catch (Exception)
            {
                return View(lstRecord.ToList());
            }
        }

        // GET: Calificacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calificacion/Create
        public ActionResult Create()
        {
            return View(new CalificacionesModel());
        }

        // POST: Calificacion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, CalificacionesModel objCalificacion)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

                try
                {
                    WCFServicioDatos.Calificaciones calificaciones = new WCFServicioDatos.Calificaciones();
                    //TblUsuario.Id = 0;
                    calificaciones.id_calificacion = objCalificacion.Id_calificacion;
                    calificaciones.id_materia = objCalificacion.Id_materia;
                    calificaciones.id_usuario = objCalificacion.Id_usuario;
                    calificaciones.calificacion = objCalificacion.calificacion;
                    calificaciones.tipo_actividad = objCalificacion.tipo_actividad.Trim();

                    bool Resval = myCliente.CrearCalificaciones(calificaciones);

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

        // GET: Calificacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calificacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calificacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calificacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
