using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpGrupal.Models;

namespace TpGrupal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Verificar(string Mail, string contraseña)
        {
            int x = BD.LoginUsuario(Mail, contraseña);
            if (x > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Alerta = "Ingrese un usuario existente";
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            BD.LogOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Registrarse()
        {
            return View();
        }
    }
}