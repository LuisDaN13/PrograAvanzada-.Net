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

        UsuarioModel modelo = new UsuarioModel();

        // -------------------------------------------------------------
        // PARA INICIAR SESION

        [HttpGet]
        public ActionResult IniciarSesionUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesionUsuario(Usuario entidad)
        {
            var respuesta = modelo.IniciarSesionUsuario(entidad);

            if(respuesta.Count > 0)
                return RedirectToAction("PantallaPrincipal", "Inicio");
            return View();
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
            var respuesta = modelo.RegistrarUsuario(entidad);

            if(respuesta > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

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