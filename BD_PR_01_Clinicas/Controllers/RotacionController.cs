using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_PR_01_Clinicas.Models;

namespace BD_PR_01_Clinicas.Controllers
{
    public class RotacionController : Controller
    {
        DataContext db = new DataContext();
        // GET: Rotacion
        public ActionResult Index()
        {
            List<Rotaciones> lista = (from t in db.tbRotacion select new Rotaciones
            {
                codigo = t.codRotacion,
                fechaInicio = t.fechaInicio.Value.ToShortDateString(),
                fechaFin = t.fechaFinal.Value.ToShortDateString()
            }).ToList();
            return View(lista);
        }

        // GET: Rotacion/Details/5
        public ActionResult Integrantes(int id)
        {
            List<tbRotacionUsuario> lista = (from t in db.tbRotacionUsuario where t.codRotacion == id  && t.estado == true select t).ToList();
            tbRotacion rotacion = (from t in db.tbRotacion where t.codRotacion == id select t).SingleOrDefault();
            ViewBag.idRotacion = id;
            ViewBag.fechaInicio = rotacion.fechaInicio.Value.ToShortDateString();
            ViewBag.fechaFinal = rotacion.fechaFinal.Value.ToShortDateString();
            return View(lista);
        }

        // GET: Rotacion/Create
        public ActionResult AgregarIntegrante(int idRotacion)
        {
            ViewBag.codUsuario = new SelectList(db.tbUsuario, "codUsuario", "nombre");
            ViewBag.idRotacion = idRotacion;
            return View();
        }

        // POST: Rotacion/Create
        [HttpPost]
        public ActionResult AgregarIntegrante(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                tbRotacionUsuario nuevo = new tbRotacionUsuario
                {
                    codRotacion = int.Parse(collection["codRotacion"]),
                    codUsuario = int.Parse(collection["codUsuario"]),
                    estado = true
                };
                db.tbRotacionUsuario.InsertOnSubmit(nuevo);
                db.SubmitChanges();
                return RedirectToAction("Integrantes");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rotacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rotacion/Edit/5
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

        // GET: Rotacion/Delete/5
        public ActionResult Delete(int idRotacion, int idUsuario)
        {
            return View();
        }

        // POST: Rotacion/Delete/5
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
