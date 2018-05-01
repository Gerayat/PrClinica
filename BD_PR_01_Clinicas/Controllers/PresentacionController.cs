using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_PR_01_Clinicas.Models;

namespace BD_PR_01_Clinicas.Controllers
{
    public class PresentacionController : Controller
    {
        DataContext dt = new DataContext();
        // GET: Presentacion
        public ActionResult Index()
        {
            List<tbPresentacion> lista = (from t in dt.tbPresentacion select t).ToList();
            return View(lista);
        }

        // GET: Presentacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Presentacion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                tbPresentacion nueva = new tbPresentacion
                {
                    presentacion = collection["presentacion"]
                };
                dt.tbPresentacion.InsertOnSubmit(nueva);
                dt.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Presentacion/Edit/5
        public ActionResult Edit(int id)
        {
            tbPresentacion editar = (from t in dt.tbPresentacion where t.codPresentacion == id select t).SingleOrDefault();
            return View(editar);
        }

        // POST: Presentacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                tbPresentacion editar = (from t in dt.tbPresentacion where t.codPresentacion == id select t).SingleOrDefault();
                editar.presentacion = collection["presentacion"];
                dt.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Presentacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Presentacion/Delete/5
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
