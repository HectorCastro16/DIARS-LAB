using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAplicacion;
using CapaDominio;

namespace PresentacionWeb.Controllers
{
    public class IntranetController : Controller
    {
        //
        // GET: /Intranet/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {

            try
            {
                String user = frm["txtUser"].ToString();
                String pass = frm["txtPassword"].ToString();

                if (appUsuario.Instancia.VerificarAcceso(user, pass))
                {
                    return RedirectToAction("Bienvenido");
                }
                else
                {
                    //ViewBag.mensaje = "User o Pass No Valido..!!!!";
                    //return View();
                    return RedirectToAction("Index", "Error", new { mensaje = "User o Pass No Valido..!!!!" });
                    
                }
            }
            catch (Exception e)
            {

                return RedirectToAction("Index", "Error", new {mensaje=e.Message });
            }

        }

        public ActionResult Bienvenido()
        {

            return View();
        }
    }
}