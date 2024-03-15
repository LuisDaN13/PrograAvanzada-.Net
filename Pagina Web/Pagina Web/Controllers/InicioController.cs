using Pagina_Web.Entidades;
using Pagina_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagina_Web.Controllers
{
    public class InicioController : Controller
    {

        // -------------------------------------------------------------
        // PARA INICIAR SESION

        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Usuario entidad)
        {
            return RedirectToAction("PantallaPrincipal", "Inicio");
        }

        // -------------------------------------------------------------
        // PARA REGISTRAR UN USUARIO

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(Usuario entidad)
        {
            return View();
        }

        // -------------------------------------------------------------
        // PARA RECUPERARA ACCESO

        [HttpGet]
        public ActionResult RecuperarAcceso() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult RecuperarAcceso(Usuario entidad)
        {
            return View();
        }
        
        // -------------------------------------------------------------
        // PARA PANTALLA PRINCIPAL

        [HttpGet]
        public ActionResult PantallaPrincipal()
        {
            return View();
        }
    }
}