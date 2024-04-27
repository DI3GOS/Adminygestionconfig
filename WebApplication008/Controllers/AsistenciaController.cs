using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;
using WebApplication008.WCFServicioDatos;

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
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objAsitencia = myCliente.ListarAsistenciasPorIdMateria(id);

            var MyAsistencia = new AsistenciasModel();

            MyAsistencia.Id_asistencia = id;

            MyAsistencia.Id_materia = objAsitencia[0].id_materia;

            MyAsistencia.Id_usuario = objAsitencia[0].id_usuario;

            MyAsistencia.Fecha = objAsitencia[0].fecha.ToShortDateString();

            if (Session["UserName"] != null)
            {
                return View(MyAsistencia);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
            WCFServicioDatos.ServiceClient myAsistente = new WCFServicioDatos.ServiceClient();
            var varMateria = myAsistente.ListarAsistenciasPorIdMateria(id).ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    var asistencia = new AsistenciasModel();

                    asistencia.Id_asistencia = varMateria[0].id_materia;
                    asistencia.Id_materia = varMateria[0].id_materia;
                    asistencia.Id_usuario = varMateria[0].id_usuario;
                    asistencia.Asistio= varMateria[0].asistio;
                    asistencia.Fecha = varMateria[0].fecha.ToString();


                    if (Session["UserName"] != null)
                    {
                        return View(asistencia);
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

        // POST: Asistencia/Edit/5
        [HttpPost]
        public ActionResult Edit(AsistenciasModel objAsistencia, FormCollection collection)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            bool resVal = false;
            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.Asistencias asistencias = new WCFServicioDatos.Asistencias();

                    asistencias.id_asistencia = objAsistencia.Id_asistencia;
                    asistencias.id_materia = objAsistencia.Id_materia;
                    asistencias.id_usuario = objAsistencia.Id_usuario;
                    asistencias.asistio = objAsistencia.Asistio;
                    asistencias.fecha = DateTime.Parse(objAsistencia.Fecha);


                    resVal = myCliente.EditarAsistencia(asistencias); //actualiza objeto Asitencias
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

        // GET: Asistencia/Delete/5
        public ActionResult Delete(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myMateria = myCliente.ListarAsistenciasPorIdMateria(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var asistencia = new AsistenciasModel();
                    asistencia.Id_asistencia = myMateria[0].id_asistencia;
                    asistencia.Id_usuario = myMateria[0].id_usuario;
                    asistencia.Id_materia = myMateria[0].id_materia;
                    asistencia.Asistio = myMateria[0].asistio;
                    asistencia.Fecha = myMateria[0].fecha.ToShortDateString();

                    if (Session["UserName"] != null)
                    {
                        return View(asistencia);
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

        // POST: Asistencia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                WCFServicioDatos.ServiceClient myAsistencia = new WCFServicioDatos.ServiceClient();
                bool Rev = myAsistencia.EliminarAsistenciaPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
