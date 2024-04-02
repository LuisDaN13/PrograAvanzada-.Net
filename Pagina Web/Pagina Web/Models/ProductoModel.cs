using Pagina_Web.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;

namespace Pagina_Web.Models
{
    public class ProductoModel
    {
        public string url = ConfigurationManager.AppSettings["urlWebApi"];

        public ConfirmacionProducto ConsultarProductos(bool MostrarTodos)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                url += "Producto/ConsultarProductos?MostrarTodos=" + MostrarTodos;
                var respuesta = client.GetAsync(url).Result;  //el GET y DELETE no llevan lo de JsonContent

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionProducto>().Result;
                }
                return null;
            }
        }
    }
}