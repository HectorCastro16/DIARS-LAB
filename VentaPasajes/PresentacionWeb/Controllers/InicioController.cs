using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionWeb.Controllers
{
    public class InicioController : Controller
    {
        [HttpGet]
        public ActionResult Index(short? i, String Mensaje)
        {
            ViewBag.i = i;
            ViewBag.m = Mensaje;
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm) {
            try
            {
                String nombre = frm["nombre"].ToString();
                return RedirectToAction("Index", new {i = 1, mensaje="Hola "+nombre});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { i = 2, mensaje = ex.Message });
            }
        }
	}
}