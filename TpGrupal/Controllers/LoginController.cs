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
                return View("Index");
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

        public ActionResult Registrar(string Mail,string Nombre, string Contraseña)
        {
            if (Mail != "" && Nombre != "" && Contraseña != "")
            {
                if (Mail != BD.VerUsuarioMail(Mail))
                {
                    ViewBag.Error = "";
                     BD.RegistarUsuario(Mail, Nombre, Contraseña);
                     return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    ViewBag.Error = "El Mail ya esta ingresado";
                    return View("Registrar");
                }
            }            
            else
            {
                ViewBag.Error = "No deje ningun campo vacio";
                return View("Registrar");
            }

        }
    }
}