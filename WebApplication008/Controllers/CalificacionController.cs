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
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objCalificacion = myCliente.ListarCalificacionesPorId(id);

            var MyCalificacion = new CalificacionesModel();

            MyCalificacion.Id_calificacion = id;
            MyCalificacion.Id_materia = objCalificacion[0].id_materia;
            MyCalificacion.Id_usuario = objCalificacion[0].id_usuario;
            MyCalificacion.calificacion = objCalificacion[0].calificacion.Value;
            MyCalificacion.tipo_actividad = objCalificacion[0].tipo_actividad;


            if (Session["UserName"] != null)
            {
                return View(MyCalificacion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
            WCFServicioDatos.ServiceClient myCalificaciones = new WCFServicioDatos.ServiceClient();
            var myCalificacion = myCalificaciones.ListarCalificacionesPorId(id).ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    var calificacion = new CalificacionesModel();

                    calificacion.Id_calificacion = myCalificacion[0].id_calificacion;
                    calificacion.Id_materia = myCalificacion[0].id_materia;
                    calificacion.Id_usuario = myCalificacion[0].id_usuario;
                    calificacion.calificacion = myCalificacion[0].calificacion.Value;
                    calificacion.tipo_actividad = myCalificacion[0].tipo_actividad;


                    if (Session["UserName"] != null)
                    {
                        return View(calificacion);
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

        // POST: Calificacion/Edit/5
        [HttpPost]
        public ActionResult Edit(Calificaciones objCalificacion, FormCollection collection)
        {
            WCFServicioDatos.ServiceClient myCalificaciones = new WCFServicioDatos.ServiceClient();
            bool resVal = false;
            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.Calificaciones calificacion = new WCFServicioDatos.Calificaciones();

                    calificacion.id_calificacion = objCalificacion.id_calificacion;
                    calificacion.id_materia = objCalificacion.id_materia;
                    calificacion.id_usuario = objCalificacion.id_usuario;
                    calificacion.calificacion = objCalificacion.calificacion;
                    calificacion.tipo_actividad = objCalificacion.tipo_actividad;


                    resVal = myCalificaciones.EditarCalificacion(calificacion); //actualiza objeto Materias
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

        // GET: Calificacion/Delete/5
        public ActionResult Delete(int id)
        {
            WCFServicioDatos.ServiceClient myCalificaciones = new WCFServicioDatos.ServiceClient();
            var myCalificacion = myCalificaciones.ListarCalificacionesPorId(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var calificacion = new CalificacionesModel();
                    calificacion.Id_calificacion = myCalificacion[0].id_calificacion;
                    calificacion.Id_materia = myCalificacion[0].id_materia;
                    calificacion.Id_usuario = myCalificacion[0].id_usuario;
                    calificacion.calificacion = myCalificacion[0].calificacion.Value;
                    calificacion.tipo_actividad = myCalificacion[0].tipo_actividad;


                    if (Session["UserName"] != null)
                    {
                        return View(calificacion);
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

        // POST: Calificacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCalificacion = new WCFServicioDatos.ServiceClient();
                bool Rev = myCalificacion.EliminarCalificacionPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
