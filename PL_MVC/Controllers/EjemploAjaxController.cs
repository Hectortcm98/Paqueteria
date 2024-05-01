using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EjemploAjaxController : Controller
    {
        [HttpGet]
        public ActionResult Tabla()
        {
            return View();
        }

    }
}