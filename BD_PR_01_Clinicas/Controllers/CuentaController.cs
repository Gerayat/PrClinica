using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_PR_01_Clinicas.Models;

namespace BD_PR_01_Clinicas.Controllers
{
    public class CuentaController : Controller
    {
        DataContext db = new DataContext();
        // GET: Cuenta
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(FormCollection collection)
        {
            tbUsuario user = (from t in db.tbUsuario
                              where t.usuario == collection["usuario"] && t.contraseña == collection["contraseña"]
                              select t).SingleOrDefault();
            if (user != null)
            {
                Session["usuario"] = collection["usuario"];
                Session["contraseña"] = collection["contraseña"];
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            Session["contraseña"] = null;
            return RedirectToAction("IniciarSesion", "Cuenta");
        }
    }
}