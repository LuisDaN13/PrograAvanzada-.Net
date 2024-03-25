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
    public class ProductoController : ApiController
    {
        [Route("Producto/ConsultarProductos")]
        [HttpGet]
        public ConfirmacionProducto ConsultarProductos(bool MostrarTodos) //GET Y DELETE: solo recibe parametros | PUT Y POST: solo recibe objetos
        {
            var respuesta = new ConfirmacionProducto();

            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var datos = db.ConsultarProductos(MostrarTodos).ToList(); //si solo espero uno sería "firstOrDefault"

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
