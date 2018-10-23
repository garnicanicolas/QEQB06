using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TpGrupal.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            return View();
        }
        public ActionResult ABMs()
        {
            return View();
        }
    }
}