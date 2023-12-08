using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sisetitulacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Acerca del por que de esta pagina";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacta con los creadores de la pagina";

            return View();
        }
        /*
        public ActionResult Login()
        {
            ViewBag.Message = "Iniciar Secion";
            return View();
        }*/
    }
}