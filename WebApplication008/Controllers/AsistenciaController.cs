using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;

namespace WebApplication008.Controllers
{
    public class AsistenciaController : Controller
    {
        // GET: Asistencia
        public ActionResult Index()
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            List<AsistenciasModel> lstRecord = new List<AsistenciasModel>();

            try
            {
                var myListaAsistencias = myCliente.ListarAsistencias();

                foreach (var item in myListaAsistencias)
                {
                    AsistenciasModel asistencia = new AsistenciasModel();

                    asistencia.Id_asistencia = item.id_asistencia;
                    asistencia.Id_materia = item.id_materia;
                    asistencia.Id_usuario = item.id_usuario;
                    asistencia.Asistio = item.asistio;

                    lstRecord.Add(asistencia);
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

        // GET: Asistencia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asistencia/Create
        public ActionResult Create()
        {
            return View(new AsistenciasModel()); 
        }

        // POST: Asistencia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, AsistenciasModel objAsistencia)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

                try
                {
                    WCFServicioDatos.Asistencias myAsistencia = new WCFServicioDatos.Asistencias();
                    //TblUsuario.Id = 0;
                    //myAsistencia.id_asistencia = objAsistencia.Id_asistencia;
                    myAsistencia.id_materia = objAsistencia.Id_materia;
                    myAsistencia.id_usuario = objAsistencia.Id_usuario;
                    myAsistencia.fecha = DateTime.Parse(objAsistencia.Fecha);
                    myAsistencia.asistio = objAsistencia.Asistio;

                    bool Resval = myCliente.CrearAsistencia(myAsistencia);

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

        // GET: Asistencia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asistencia/Edit/5
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

        // GET: Asistencia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asistencia/Delete/5
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
