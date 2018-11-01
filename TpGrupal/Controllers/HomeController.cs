using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TpGrupal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Instrucciones()
        {
            return View();
        }
        public ActionResult AdminCategorias()
        {
            return View();
        }
    }
}