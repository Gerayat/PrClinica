﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_PR_01_Clinicas.Models;

namespace BD_PR_01_Clinicas.Controllers
{
    public class CategoriaController : Controller
    {
        DataContext dt = new DataContext();
        // GET: Categoria
        public ActionResult Index()
        {
            List<tbCategoria> lista = (from t in dt.tbCategoria select t).ToList();
            return View(lista);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                tbCategoria nueva = new tbCategoria
                {
                    categoria = collection["categoria"]
                };
                dt.tbCategoria.InsertOnSubmit(nueva);
                dt.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            tbCategoria editar = (from t in dt.tbCategoria where t.codCategoria == id select t).SingleOrDefault();
            return View(editar);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                tbCategoria editar = (from t in dt.tbCategoria where t.codCategoria == id select t).SingleOrDefault();
                editar.categoria = collection["categoria"];
                dt.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
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
