using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;
using WebApplication008.WCFServicioDatos;

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
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objTrabajo = myCliente.ListarTrabajosPorId(id);

            var MyTrabajo = new TrabajoModel();

            MyTrabajo.id_trabajo = id;

            MyTrabajo.id_usuario = objTrabajo[0].id_usuario;

            MyTrabajo.id_materia = objTrabajo[0].id_materia;

            MyTrabajo.tipo_trabajo = objTrabajo[0].tipo_trabajo.Trim();

            MyTrabajo.archivo = objTrabajo[0].archivo.Trim();

            MyTrabajo.fecha_entrega = objTrabajo[0].fecha_entrega.Value;

            if (Session["UserName"] != null)
            {
                return View(MyTrabajo);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myTrabajo = myCliente.ListarTrabajosPorId(id).ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    var trabajo = new TrabajoModel();

                    trabajo.id_trabajo = myTrabajo[0].id_trabajo;
                    trabajo.id_usuario = myTrabajo[0].id_usuario;
                    trabajo.id_materia = myTrabajo[0].id_materia;
                    trabajo.tipo_trabajo = myTrabajo[0].tipo_trabajo.Trim();
                    trabajo.archivo = myTrabajo[0].archivo.Trim();
                    trabajo.fecha_entrega = myTrabajo[0].fecha_entrega.Value;

                    if (Session["UserName"] != null)
                    {
                        return View(trabajo);
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

        // POST: Trabajos/Edit/5
        [HttpPost]
        public ActionResult Edit(TrabajoModel objTrabajo, FormCollection collection)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            bool resVal = false;
            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.Trabajos trabajo = new WCFServicioDatos.Trabajos();

                    trabajo.id_trabajo = objTrabajo.id_trabajo;
                    trabajo.id_usuario = objTrabajo.id_usuario;
                    trabajo.id_materia = objTrabajo.id_materia;
                    trabajo.tipo_trabajo = objTrabajo.tipo_trabajo.Trim();
                    trabajo.archivo = objTrabajo.archivo.Trim();
                    trabajo.fecha_entrega = objTrabajo.fecha_entrega;

                    resVal = myCliente.EditarTrabajo(trabajo); //actualiza objeto Materias
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

        // GET: Trabajos/Delete/5
        public ActionResult Delete(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myTrabajo = myCliente.ListarTrabajosPorId(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var trabajo = new TrabajoModel();
                    trabajo.id_trabajo = myTrabajo[0].id_trabajo;
                    trabajo.id_usuario = myTrabajo[0].id_usuario;
                    trabajo.id_materia = myTrabajo[0].id_materia;
                    trabajo.tipo_trabajo = myTrabajo[0].tipo_trabajo.Trim();
                    trabajo.archivo = myTrabajo[0].archivo.Trim();
                    trabajo.fecha_entrega = myTrabajo[0].fecha_entrega.Value;

                    if (Session["UserName"] != null)
                    {
                        return View(trabajo);
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

        // POST: Trabajos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
                bool Rev = myCliente.EliminarTrabajoPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
