using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionWeb.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index(String mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }
	}
}