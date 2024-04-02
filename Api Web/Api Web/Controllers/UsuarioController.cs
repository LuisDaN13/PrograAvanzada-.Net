using Api_Web.Entidades;
using Api_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_Web.Controllers
{
    public class UsuarioController : ApiController
    {
        // --------------------------------------------------------------------

        [Route("Usuario/ConsultarUsuario")]
        [HttpGet]
        public ConfirmacionUsuario ConsultarUsuario(long Consecutivo)
        {
            var respuesta = new ConfirmacionUsuario();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var datos = db.ConsultarUsuario(Consecutivo).FirstOrDefault();

                    if (datos != null)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }
            return respuesta;
        }

        [Route("Usuario/ActualizarUsuario")]
        [HttpPut]
        public Confirmacion ActualizarUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var resp = db.ActualizarUsuario(entidad.Consecutivo, entidad.Contrasenna, entidad.Nombre, entidad.CorreoElectronico);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "La información ya se encuentra registrada en el sistema";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Su información no se pudo registrar en este momento";
            }
            return respuesta;
        }

        // --------------------------------------------------------------------

        [Route("Usuario/ConsultarUsuarioSC")]
        [HttpGet]
        public ConfirmacionUsuario ConsultarUsuarioSC(long Consecutivo)
        {
            var respuesta = new ConfirmacionUsuario();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var datos = db.ConsultarUsuario(Consecutivo).FirstOrDefault();

                    if (datos != null)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }
            return respuesta;
        }

        [Route("Usuario/ActualizarUsuarioSC")]
        [HttpPut]
        public Confirmacion ActualizarUsuarioSC(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var resp = db.ActualizarUsuarioSC(entidad.Consecutivo, entidad.Identificacion, entidad.Nombre, entidad.CorreoElectronico, entidad.Estado, entidad.ConsecutivoRol);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su información no se pudo actualizar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Su información no se pudo actualizar en este momento";
            }
            return respuesta;
        }

        // --------------------------------------------------------------------

        [Route("Usuario/ConsultarUsuarios")]
        [HttpGet]
        public ConfirmacionUsuario ConsultarUsuarios()
        {
            var respuesta = new ConfirmacionUsuario();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var datos = db.ConsultarUsuarios().ToList();

                    if (datos.Count > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }
            return respuesta;
        }

        // --------------------------------------------------------------------

        [Route("Usuario/RegistrarUsuario")]
        [HttpPost]
        public Confirmacion RegistrarUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var resp = db.RegistrarUsuarioSCRUD(entidad.Identificacion, entidad.Contrasenna, entidad.Nombre, entidad.CorreoElectronico, entidad.ConsecutivoRol).FirstOrDefault();

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "La información ya se encuentra registrada en el sistema";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Su información no se pudo registrar en este momento";
            }
            return respuesta;
        }

        // --------------------------------------------------------------------

        [Route("Usuario/EliminarUsuario")]
        [HttpDelete]
        public Confirmacion EliminarUsuario(long Consecutivo)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var resp = db.EliminarUsuario(Consecutivo);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "El producto no se pudo eliminar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presento un error en el sistema";
            }
            return respuesta;
        }

        // --------------------------------------------------------------------

        [Route("Usuario/ConsultarTiposRoles")]
        [HttpGet]
        public ConfirmacionTiposRoles ConsultarTiposRoles()
        {
            var respuesta = new ConfirmacionTiposRoles();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var datos = db.ConsultarTiposRoles().ToList();

                    if (datos.Count > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }
            return respuesta;
        }
    }
}
