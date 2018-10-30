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
        public ActionResult Verificar(Usuarios x)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Alerta = "";
                return View("Index", x);
            }
            else
            {
                //si es válido
                int a = BD.LoginUsuario(x);
                if (a > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Alerta = "Ingrese un usuario existente";
                    return View("Index");
                }
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

        public ActionResult VerificarRegistro(Usuarios x)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Alerta = "";
                return View("Index", x);
            }
            else
            {
                bool a = BD.RegistarUsuario(x);
                if (a == true)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.Alerta = "Ingrese un usuario existente";
                    return View("Index");
                }                
            }
        }
    }
}


/* =======
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
                >>>>>>> 3e2c2a66f1569699afdbd0bd8873ad1db19c6f31
                            }
                      */
