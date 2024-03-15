using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagina_Web.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult IniciarSesion()
        {
            return View();
        }

        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        public ActionResult PantallaPrincipal()
        {
            return View();
        }
    }
}