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
            //si es válido
            if (x.Mail == "" || x.Contraseña == "" || x.Mail == null || x.Contraseña == null)
            {
                ViewBag.Alerta = "Complete todos los campos";
                return View("Index");
            }
            else
            {
                int a = BD.LoginUsuario(x);
                if (a > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Alerta = "Ingrese datos correctos";
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
            if (x.Mail == "" || x.Contraseña == "" || x.Nombre == "" || x.Mail == null || x.Contraseña == null || x.Nombre == null)
            {
                ViewBag.Alerta = "Complete todos los campos";
                return View("Registrarse");
            }
            else
            {
                if (x.Mail == BD.VerUsuarioMail(x.Mail))
                {
                    ViewBag.Alerta = "Ese usuario ya fue creado";
                    bool y = BD.RegistarUsuario(x);
                    if (y == false)
                    {
                        ViewBag.UserNone = "Ese nombre de usuario ya existe";
                    }
                    return View("Registrarse");
                }
                else
                {
                    if (x.Contraseña.Length > 5 && x.Contraseña.Length < 16)
                    {
                        bool a = BD.RegistarUsuario(x);
                        if (a)
                        {
                            return RedirectToAction("Index", "Login");
                        }
                        else
                        {
                            ViewBag.Alerta = "Ese usuario ya fue creado";
                            return View("Registrarse");
                        }
                    }
                    else
                    { 
                        return View("Registrarse");
                    }
                }
            }
        }
    }
}
