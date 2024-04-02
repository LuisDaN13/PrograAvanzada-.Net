using Api_Web.Entidades;
using Api_Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web.Http;

namespace Api_Web.Controllers
{
    public class InicioController : ApiController
    {
        UtilitariosModel model = new UtilitariosModel();

        [Route("Inicio/RegistrarUsuario")]
        [HttpPost]
        public Confirmacion RegistrarUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    int resp = db.RegistrarUsuario(entidad.Identificacion, entidad.Contrasenna, entidad.Nombre, entidad.CorreoElectronico);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su información ya se encuentra registrada en el sistema";
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

        [Route("Inicio/IniciarSesionUsuario")]
        [HttpPost]
        public ConfirmacionUsuario IniciarSesionUsuario(Usuario entidad)
        {
            var respuesta = new ConfirmacionUsuario();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var datos = db.IniciarSesionUsuario(entidad.Identificacion, entidad.Contrasenna).FirstOrDefault();

                    if (datos != null)
                    {
                        if(datos.Temporal && DateTime.Now > datos.Vencimiento)
                        {
                            respuesta.Codigo = -1;
                            respuesta.Detalle = "Su contraseña temporal ha caducado";
                        }
                        else 
                        {
                            respuesta.Codigo = 0;
                            respuesta.Detalle = string.Empty;
                            respuesta.Dato = datos;
                        }
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo validar su informacion de ingreso";
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

        [Route("Inicio/RecuperarAccesoUsuario")]
        [HttpPost]
        public Confirmacion RecuperarAccesoUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var datos = db.RecuperarAccesoUsuario(entidad.Identificacion, entidad.CorreoElectronico).FirstOrDefault();

                    if (datos != null)
                    { 
                        string rutaHTML = AppDomain.CurrentDomain.BaseDirectory + "Password.html";
                        string contenidoHTML = File.ReadAllText(rutaHTML);

                        contenidoHTML = contenidoHTML.Replace("@@Nombre", datos.Nombre);
                        contenidoHTML = contenidoHTML.Replace("@@Contrasenna", datos.Contrasenna);
                        contenidoHTML = contenidoHTML.Replace("@@Vencimiento", datos.Vencimiento.ToString("dd/MM/yyyy HH:mm:ss tt"));



                        //MANDAR EL CORREO
                        model.EnviarCorreo(datos.CorreoElectronico, "Acceso Temporal", contenidoHTML);

                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo vaidar su informacion de ingreso";
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
