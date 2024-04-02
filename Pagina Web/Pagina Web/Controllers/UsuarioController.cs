using Pagina_Web.Entidades;
using Pagina_Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Pagina_Web.Controllers
{
    [FiltroSeguridad]
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class UsuarioController : Controller
    {
        UsuarioModel modelo = new UsuarioModel();

        [HttpGet]
        public ActionResult ActualizarUsuario()
        {
            var resp = modelo.ConsultarUsuario();
            return View(resp.Dato);
        }
        [HttpPost]
        public ActionResult ActualizarUsuario(Usuario entidad)
        {
            var respuesta = modelo.ActualizarUsuario(entidad);

            if (respuesta.Codigo == 0)
            {
                Session["NombreUsuario"] = entidad.Nombre;
                return RedirectToAction("ActualizarUsuario", "Usuario");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // ------------- VER ----------------------------------------------------------
        [HttpGet]
        public ActionResult ConsultaUsuarios()
        {
            var respuesta = modelo.ConsultarUsuarios();

            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Usuario>());
            }
        }

        // ------------- REGISTRO -----------------------------------------------------
        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            CargarViewBagRoles();

            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(Usuario entidad)
        {
            var respuesta = modelo.RegistrarUsuario(entidad);

            if (respuesta.Codigo == 0)
            {
               return RedirectToAction("ConsultaUsuarios", "Usuario");
            }
            else
            {
                CargarViewBagRoles();

                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // ------------- ACTUALIZAR -----------------------------------------------------

        [HttpGet]
        public ActionResult ActualizarUsuarioSC(long id)
        {
            var resp = modelo.ConsultarUsuarioSC(id);
            CargarViewBagRoles();
            return View(resp.Dato);
        }

        [HttpPost]
        public ActionResult ActualizarUsuarioSC(Usuario entidad)
        {
            var respuesta = modelo.ActualizarUsuarioSC(entidad);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("ConsultaUsuarios", "Usuario");
            }
            else
            {
                CargarViewBagRoles();

                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // ------------- ELIMINAR -----------------------------------------------------
        [HttpGet]
        public ActionResult EliminarUsuario(long id)
        {
            var respuesta = modelo.EliminarUsuario(id);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("ConsultaUsuarios", "Usuario");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // ------------- EXTRAS -----------------------------------------------------

        private void CargarViewBagRoles()
        {
            var respuesta = modelo.ConsultarTiposRoles();
            var tiposRoles = new List<SelectListItem>();

            tiposRoles.Add(new SelectListItem { Text = "Seleccione un rol...", Value = "" });
            foreach (var item in respuesta.Datos)
                tiposRoles.Add(new SelectListItem { Text = item.NombreRol, Value = item.ConsecutivoRol.ToString() });

            ViewBag.TiposRoles = tiposRoles;
        }
    }
}