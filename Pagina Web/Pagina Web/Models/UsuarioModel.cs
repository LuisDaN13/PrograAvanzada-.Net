using Pagina_Web.Entidades;
using System;
using System.Collections.Generic;
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
        public string url = "https://localhost:44307/";

        public int RegistrarUsuario(Usuario entidad)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                url = url += "Inicio/RegistrarUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<Usuario> IniciarSesionUsuario(Usuario entidad)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                url = url += "Inicio/IniciarSesionUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<List<Usuario>>().Result;

                return null;
            }
        }
    }
}