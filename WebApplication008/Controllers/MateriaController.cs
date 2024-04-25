using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication008.Models;
using WebApplication008.WCFServicioDatos;

namespace WebApplication008.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            List<MateriaModel> lstRecord = new List<MateriaModel>();
            var myListaMaterias = myCliente.ListarMaterias();

            foreach (var item in myListaMaterias)
            {
                MateriaModel materia = new MateriaModel();

                materia.Id_materia = item.id_materia;
                materia.Nombre = item.nombre.Trim();
                materia.Codigo = item.codigo.Trim();
                materia.Descripcion = item.descripcion.Trim();

                lstRecord.Add(materia);
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

        // GET: Materia/Details/5
        public ActionResult Details(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objMateria = myCliente.ListarMateriasPorId(id);

            var MyMateria = new MateriaModel();

            MyMateria.Id_materia = id;

            MyMateria.Nombre = objMateria[0].nombre.Trim();

            MyMateria.Codigo = objMateria[0].codigo.Trim();

            MyMateria.Descripcion = objMateria[0].descripcion.Trim();

            if (Session["UserName"] != null)
            {
                return View(MyMateria);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            return View(new MateriaModel()); //Se actualiza a UserModel
        }

        // POST: Materia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, MateriaModel objMateria)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

                try
                {
                    WCFServicioDatos.Materias TblMateria = new WCFServicioDatos.Materias();
                    //TblUsuario.Id = 0;
                    TblMateria.id_materia = objMateria.Id_materia;
                    TblMateria.nombre = objMateria.Nombre.Trim();
                    TblMateria.codigo = objMateria.Codigo.Trim();
                    TblMateria.descripcion = objMateria.Descripcion.Trim();

                    bool Resval = myCliente.CrearMateria(TblMateria);

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

        // GET: Materia/Edit/5
        public ActionResult Edit(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myMateria = myCliente.ListarMateriasPorId(id).ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    var materia = new MateriaModel();

                    materia.Id_materia = myMateria[0].id_materia;
                    materia.Nombre = myMateria[0].nombre;
                    materia.Codigo = myMateria[0].codigo;
                    materia.Descripcion = myMateria[0].descripcion;

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
    

        // POST: Materia/Edit/5
        [HttpPost]
        public ActionResult Edit(MateriaModel objMateria, FormCollection collection)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            bool resVal = false;
            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.Materias materias = new WCFServicioDatos.Materias();

                    materias.id_materia = objMateria.Id_materia;
                    materias.nombre = objMateria.Nombre;
                    materias.codigo = objMateria.Codigo;
                    materias.descripcion = objMateria.Descripcion;
                
                    resVal = myCliente.EditarMateria(materias); //actualiza objeto Materias
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Materia/Delete/5
        public ActionResult Delete(int id)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var myMateria = myCliente.ListarMateriasPorId(id);

            try
            {
                if (ModelState.IsValid)
                {
                    var materia = new MateriaModel();
                    materia.Id_materia = myMateria[0].id_materia;
                    materia.Nombre  = myMateria[0].nombre.Trim();
                    materia.Codigo = myMateria[0].codigo.Trim();
                    materia.Descripcion = myMateria[0].descripcion.Trim();

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

        // POST: Materia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
                bool Rev = myCliente.EliminarMateriaPorId(id);                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
