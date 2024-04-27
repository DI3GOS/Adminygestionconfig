using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;

namespace WebApplication008.Controllers
{
    public class TrabajosController : Controller
    {
        // GET: Trabajos
        public ActionResult Index()
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            List<TrabajoModel> lstRecord = new List<TrabajoModel>();

            try
            {
                
                var myListaTrabajos = myCliente.ListarTrabajos();

                foreach (var item in myListaTrabajos)
                {
                    TrabajoModel trabajo = new TrabajoModel();

                    trabajo.id_trabajo = item.id_trabajo;
                    trabajo.id_usuario = item.id_usuario;
                    trabajo.id_materia = item.id_materia;
                    trabajo.tipo_trabajo = item.tipo_trabajo.Trim();
                    trabajo.archivo = item.archivo.Trim();
                    trabajo.fecha_entrega = item.fecha_entrega.Value;


                    lstRecord.Add(trabajo);
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

        // GET: Trabajos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trabajos/Create
        public ActionResult Create()
        {
            return View(new TrabajoModel());
        }

        // POST: Trabajos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, TrabajoModel objTrabajo)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

                try
                {
                    WCFServicioDatos.Trabajos trabajos = new WCFServicioDatos.Trabajos();
                    //TblUsuario.Id = 0;
                    trabajos.id_trabajo = objTrabajo.id_trabajo;
                    trabajos.id_usuario = objTrabajo.id_usuario;
                    trabajos.id_materia = objTrabajo.id_materia;
                    trabajos.tipo_trabajo = objTrabajo.tipo_trabajo.Trim();
                    trabajos.archivo = objTrabajo.archivo.Trim();
                    trabajos.fecha_entrega = objTrabajo.fecha_entrega;

                    bool Resval = myCliente.CrearTrabajo(trabajos);

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

        // GET: Trabajos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trabajos/Edit/5
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

        // GET: Trabajos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trabajos/Delete/5
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
