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

            if (respuesta.Codigo == 0)
                return RedirectToAction("PantallaPrincipal", "Inicio");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
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

            if (respuesta.Codigo == 0)
                return RedirectToAction("IniciarSesionUsuario", "Inicio");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // -------------------------------------------------------------
        // PARA RECUPERARA ACCESO

        [HttpGet]
        public ActionResult RecuperarAccesoUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RecuperarAccesoUsuario(Usuario entidad)
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