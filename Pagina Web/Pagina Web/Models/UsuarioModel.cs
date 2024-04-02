using Pagina_Web.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace Pagina_Web.Models
{
    public class UsuarioModel
    {
        public Confirmacion RegistrarUsuario(Usuario entidad)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Inicio/RegistrarUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionUsuario IniciarSesionUsuario(Usuario entidad)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Inicio/IniciarSesionUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                }
                return null;
            }
        }

        public Confirmacion RecuperarAccesoUsuario(Usuario entidad)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Inicio/RecuperarAccesoUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        // -------------------------------------------------------------------------------

        public ConfirmacionUsuario ConsultarUsuarios()
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ConsultarUsuarios";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                }
                return null;
            }
        }
        public ConfirmacionUsuario ConsultarUsuario()
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                long Consecutivo = long.Parse(HttpContext.Current.Session["Consecutivo"].ToString());
                string url = ConfigurationManager.AppSettings["urlWebApi"] +"Usuario/ConsultarUsuario?Consecutivo=" + Consecutivo;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                }
                return null;
            }
        }
        public ConfirmacionUsuario ConsultarTiposRoles()
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ConsultarTiposRoles";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                }
                return null;
            }
        }

        // -------------------------------------------------------------------------------

        public Confirmacion ActualizarUsuario(Usuario entidad)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                entidad.Consecutivo = long.Parse(HttpContext.Current.Session["Consecutivo"].ToString());

                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ActualizarUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        // -------------------------------------------------------------------------------
        public ConfirmacionUsuario ConsultarUsuarioSC(long Consecutivo)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ConsultarUsuarioSC?Consecutivo=" + Consecutivo;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                }
                return null;
            }
        }
        public Confirmacion ActualizarUsuarioSC(Usuario entidad)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ActualizarUsuarioSC";
                JsonContent jsonEntidad = JsonContent.Create(entidad);      
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        // -------------------------------------------------------------------------------
        public Confirmacion EliminarUsuario(long Consecutivo)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/EliminarUsuario?Consecutivo=" + Consecutivo;
                var respuesta = client.DeleteAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
    }

}