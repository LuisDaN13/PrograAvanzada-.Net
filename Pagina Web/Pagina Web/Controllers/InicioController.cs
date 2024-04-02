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
        ProductoModel modeloPro = new ProductoModel();

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
            {
                Session["Consecutivo"] = respuesta.Dato.Consecutivo;
                Session["NombreUsuario"] = respuesta.Dato.Nombre;
                Session["RolUsuario"] = respuesta.Dato.ConsecutivoRol;
                Session["NombreRol"] = respuesta.Dato.NombreRol;
                return RedirectToAction("PantallaPrincipal", "Inicio");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // -------------------------------------------------------------
        // PARA CERRAR SESIÓN

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult CerrarSesionUsuario()
        {
            Session.Clear();
            return RedirectToAction("IniciarSesionUsuario","Inicio");
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
            var respuesta = modelo.RecuperarAccesoUsuario(entidad);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("IniciarSesionUsuario", "Inicio");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // -------------------------------------------------------------
        // PARA PANTALLA PRINCIPAL

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult PantallaPrincipal()
        {
            var respuesta = modeloPro.ConsultarProductos(false);

            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Producto>());
            }
        }
    }
}