using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_PR_01_Clinicas.Models;

namespace BD_PR_01_Clinicas.Controllers
{
    public class UsuarioController : Controller
    {
        DataContext dt = new DataContext();
        // GET: Usuario
        public ActionResult Index()
        {
            List<tbUsuario> lista = (from t in dt.tbUsuario select t).ToList();
            return View(lista);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            tbUsuario item = (from t in dt.tbUsuario
                              where t.codUsuario == id
                              select t).SingleOrDefault();
            ViewBag.tUsuario = item.tipoUsuario;
            return View(item);
        }

        // GET: Usuario/Create
        public ActionResult CreateEstudiante()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult CreateEstudiante(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (collection["password"] == collection["repetir"])
                {
                    tbUsuario nuevo = new tbUsuario
                    {
                        tipoUsuario = 2,
                        nombre = collection["nombre"],
                        dpi = collection["dpi"],
                        carnet = collection["carnet"],
                        fechaNacimiento = DateTime.Parse(collection["fechaNacimiento"]),
                        usuario = collection["password"],
                        password = collection["password"]
                    };
                    dt.tbUsuario.InsertOnSubmit(nuevo);
                    dt.SubmitChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Las Contraseñas no coinciden.");
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
